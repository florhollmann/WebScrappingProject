using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Compat.Web;
using System.Net;

namespace WebScrapping
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] elFacundo = { "http://www.cervantesvirtual.com/obra-visor/vida-de-juan-facundo-quiroga--0/html/fee191b4-82b1-11df-acc7-002185ce6064_3.html#I_1_", "http://www.cervantesvirtual.com/obra-visor/vida-de-juan-facundo-quiroga--0/html/fee191b4-82b1-11df-acc7-002185ce6064_4.html#I_8_", "http://www.cervantesvirtual.com/obra-visor/vida-de-juan-facundo-quiroga--0/html/fee191b4-82b1-11df-acc7-002185ce6064_5.html#I_13_", "http://www.cervantesvirtual.com/obra-visor/vida-de-juan-facundo-quiroga--0/html/fee191b4-82b1-11df-acc7-002185ce6064_6.html#I_18_", "http://www.cervantesvirtual.com/obra-visor/vida-de-juan-facundo-quiroga--0/html/fee191b4-82b1-11df-acc7-002185ce6064_7.html#I_24_" };


            string innerBodyScrapped;
            HtmlWeb cWeb = new HtmlWeb();
            Random rand = new Random();
            int i = rand.Next(elFacundo.Length);

            HtmlDocument doc = cWeb.Load(elFacundo[i]);

            foreach (var item in doc.DocumentNode.SelectNodes("//*[@id='obra']") )
            {

                innerBodyScrapped = WebUtility.HtmlDecode(item.InnerText).Replace("\n", "")
                                                                            .Replace("\r", "")
                                                                            .Replace("\t", "")
                                                                            .Replace("[", "")
                                                                            .Replace("]", "");
                                                        
                string[] sentenceArr = innerBodyScrapped.Split('.');
                int index = rand.Next(sentenceArr.Length);
                if (sentenceArr[index].Length > 1 && sentenceArr[index].Length < 280)
                {
                    Console.WriteLine(sentenceArr[index]);
                }
                

            }
            Console.Read();
        }
    }
}
