using System.IO;
using System.Net;
using HtmlAgilityPack;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace UltimateDictionary
{

    class Translator
    {
        public class WordTranslation
        {
            public string word;
            public string initial;
            public string translation;
            public string definition;
            public WordTranslation(string word)
            {
                this.word = word;
                initial = "";
                translation = "";
            }
        }       
        HtmlDocument doc;
        void Load(string word)
        {
            string answer = GetSiteAnswer(word);
            doc = new HtmlDocument();
            doc.LoadHtml(answer);
        }

        public string GetOxfordDefinition(string word)
        {
            string url = "https://en.oxforddictionaries.com/definition/";
            string str;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url + word);
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:17.0) Gecko/20100101 Firefox/17.0";
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            req.ContentType = "application/x-www-form-urlencoded";
            var ans = req.GetResponse();
            var strm = ans.GetResponseStream();
            StreamReader sr = new StreamReader(strm);
            str = sr.ReadToEnd();
            sr.Close();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(str);


            if (doc.DocumentNode.SelectSingleNode(".//span[@class='hw']") == null)
                return "";
            HtmlNodeCollection grambs = doc.DocumentNode.SelectNodes(".//section[@class='gramb']");
            if (grambs == null)
                return "";

            string mainWord = doc.DocumentNode.SelectSingleNode(".//span[@class='hw']").InnerText + "\n";
            string allMessage = "\"" + mainWord;

            foreach (HtmlNode gramb in grambs)
            {
                string gramPartOfSpeech = gramb.SelectSingleNode(@".//span[@class='pos']").InnerText;
                allMessage += gramPartOfSpeech + "\n";

                HtmlNodeCollection meanings = gramb.SelectNodes(@".//ul[@class='semb']/li/div[@class='trg']");
                foreach (HtmlNode meaning in meanings)
                {
                    string iteration = meaning.SelectSingleNode(@"./p/span[@class='iteration']").InnerText + " ";
                    if (iteration == " ")
                        iteration = "";

                    var meann = meaning.SelectSingleNode(@"./p/span[@class='ind']");
                    string mean = "";
                    if (meann != null)
                        mean = meaning.SelectSingleNode(@"./p/span[@class='ind']").InnerText;
                    else
                        continue;

                    string synonyms = "";
                    HtmlNodeCollection synonymsColection = meaning.SelectNodes(@"./div/div/div[@class='exs']");
                    if (synonymsColection != null)
                    {
                        foreach (HtmlNode synonymLine in synonymsColection)
                        {
                            string synLine = synonymLine.InnerText;
                            if(synLine.Length>50)
                            {
                                int sixComma = synLine.IndexOf(",", 50);
                                if (sixComma > -1)
                                    synLine = synLine.Substring(0, sixComma);
                            }
                            synonyms += synLine + "\n";
                        }
                        synonyms = "synonyms: " + synonyms;
                    }
                    allMessage += iteration + mean + "\n" + synonyms;

                    /*
                                        HtmlNodeCollection detailedMeanings = meaning.SelectNodes(@".//li[@class='subSense']");
                                        foreach (HtmlNode detailedMeaning in detailedMeanings)
                                        {
                                            string subIteration = detailedMeaning.SelectSingleNode(@".//span[@class='subsenseIteration']").InnerText;
                                            string subMean = detailedMeaning.SelectSingleNode(@".//span[@class='ind']").InnerText;
                                            string subSynonyms = detailedMeaning.SelectSingleNode(@".//div[@class='exs']").InnerText;

                                            allMessage += subIteration + " " + subMean + "\n" + "synonyms: " + subSynonyms + "\n";
                                        }*/



                    /*
                        string betterText = "";
                    if (headline.InnerText.Length>1 && char.IsDigit(headline.InnerText[0]))
                        betterText = headline.InnerText.Insert(1, ". ");
                    else
                        betterText = headline.InnerText;
                        
                    allMessage += betterText + "\n";*/
                }
            }
            allMessage +="\"";
            allMessage = allMessage.Replace("&#39;", "'").Replace("&amp;", " ");
            return allMessage;
        }

        public WordTranslation makeTranslations(string word)
        {
            string initialWord;

            var thisTranslation = GetDerivedTranslation(word);

            var InitTranslation = GetInitialTranslation(word);
            initialWord = InitTranslation.word;
            
            //потому что плохой перевод у форм слова
            thisTranslation.translation = ToThreeColumns(InitTranslation.translation);

            if (initialWord != thisTranslation.word)//не изначальное слово
                thisTranslation.initial = initialWord;
            try
            {
                thisTranslation.definition = GetOxfordDefinition(word);
            }
            catch (System.Exception ee)
            {
                File.AppendAllText(@"C:\111.txt", word + " " + ee.Message + "\n");
            }            

            return thisTranslation;
        }

        WordTranslation GetInitialTranslation(string word)
        {
            Load(word);
            if (HasInitialForm())
            {
                word = GetInitialWord();
                Load(word);
            }

            WordTranslation initial = new WordTranslation(word);
            initial.translation = GetDefinition(word);
            return initial;
        }
        List<WordTranslation> GetDerivedWords(string word, string block)
        {
            List<string> derivedWords = GetListDerivedWords(word, block);
            if (derivedWords == null)
                return null;
            List<WordTranslation> ld = new List<WordTranslation>();
            foreach (var derivedWord in derivedWords)
            {
                ld.Add(GetDerivedTranslation(derivedWord));
            }
            return ld;
        }
        bool isAlreadyInTheDictionary(string word, List<string> text)
        {
            if (text.Contains( word))
                return true;

            return false;
        }
        List<string> GetListDerivedWords(string word, string block)
        {
            Load(word);
            var similarWords = doc.DocumentNode.SelectNodes(block);
            if (similarWords == null)
                return null;

            List<string> listForms = new List<string>();
            foreach (var similar in similarWords)
            {
                listForms.Add(similar.InnerHtml.Split(' ')[0]);
            }

            return listForms.Distinct().ToList();
        }
        WordTranslation GetDerivedTranslation(string derivedWord)
        {
            Load(derivedWord);
            WordTranslation derivedTrans = new WordTranslation(derivedWord);
            derivedTrans.translation = GetDefinition(derivedWord);
            return derivedTrans;
        }
        string GetDefinition(string word)
        {
            var yandexTranslate = doc.DocumentNode.SelectNodes("//*[@class='light_tr']");
            if (yandexTranslate != null)
            {
                string toNormalView = yandexTranslate[0].InnerText;
                toNormalView = toNormalView.Replace("-", "").Trim().ToLower();
                toNormalView = toNormalView.Replace("&ensp;", "");
                return toNormalView;
            }

            if (doc.GetElementbyId("wd_content").ChildNodes[1].InnerText.Contains("Добавить пример")
                  || doc.GetElementbyId("wd_content").ChildNodes[1].InnerText.Contains("Посмотреть в других словарях"))
                return "";

            if (doc.GetElementbyId("wd_content").ChildNodes[1].InnerText.Contains("прилагательное"))
            {
                string toNormalView = doc.GetElementbyId("wd_content").ChildNodes[2].InnerText;
                toNormalView = toNormalView.Replace("-", "").Trim().ToLower();
                toNormalView = toNormalView.Replace("&ensp;", "");
                return toNormalView;
            }

            string translation = "";
            var transNode = doc.DocumentNode.SelectSingleNode(".//span[@class='t_inline_en']");
            if (transNode != null)
                translation = transNode.InnerText;            

            return translation;
        }
        string GetInitialWord()
        {
            HtmlNode wordFormUrlNode = doc.GetElementbyId("word_forms").ChildNodes.Where(f => f.Name == "a").ToList()[0];
            string pathToInitial = wordFormUrlNode.Attributes[0].Value;
            string InitialWord = pathToInitial.Split('/')[2];
            return InitialWord;
        }
        bool HasInitialForm()
        {
            bool hasNoForms = doc.GetElementbyId("word_forms") == null;
            if (hasNoForms)
                return false;

            if (doc.GetElementbyId("word_forms").ChildNodes.Any(f => f.Name == "a"))
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
        string GetSiteAnswer(string word)
        {
            string url = "http://wooordhunt.ru/word/";
            string str;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url + word);
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:17.0) Gecko/20100101 Firefox/17.0";
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            req.ContentType = "application/x-www-form-urlencoded";
            var ans = req.GetResponse();
            var strm = ans.GetResponseStream();
            StreamReader sr = new StreamReader(strm);
            str = sr.ReadToEnd();
            sr.Close();

            return str;
        }

        string ToThreeColumns(string str)
        {
            int f = 0, s = 0, t = 0;
            int splitter = 22;
            string resultStr = "";
            if (str.Length > splitter + 2 && str.IndexOf(",", splitter) > 0)//если есть запятая после 15 символа
            {
                f = str.IndexOf(",", splitter);
                resultStr = str.Substring(0, f);
            }
            else
                return str + "\t\t";//если нет,то возвращаем всю строку

            if (str.Length > f + splitter + 2 && str.IndexOf(",", f + splitter) > 0)//если есть запятая после f+ 15 символа, делаем вторую часть
            {
                s = str.IndexOf(",", f + splitter);
                resultStr += "\t" + str.Substring(f + 2, s - f - 2);
            }
            else
                return resultStr += "\t" + str.Substring(f + 2) + "\t";//если нет,то возвращаем первую часть и оставшуюс строку

            if (str.Length > s + splitter + 2 && str.IndexOf(",", s + splitter) > 0)//если есть запятая после s+ 15 символа, делаем третью часть и возвращаем резульат
            {
                t = str.IndexOf(",", s + splitter);
                return resultStr += "\t" + str.Substring(s + 2, t - s - 2);
            }
            else
                return resultStr += "\t" + str.Substring(s + 2);//если нет,то возвращаем первую часть и оставшуюс строку
        }
    }
}
