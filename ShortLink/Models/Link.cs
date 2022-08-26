using System.ComponentModel.DataAnnotations.Schema;

namespace ShortLink.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ShortLink { get; set; }
        public string CreateDate { get; set; }
        public int Transition { get; set; }

        
        public static string GetShortLink()
        {
            string symbols = "abcdefghijklmnopqrstuvwxyz";
            Random r = new Random();
            char GetRandomChar()
            {
                var index = r.Next(symbols.Length);
                return symbols[index];
            }
            string result = "https://localhost:7125/";
            for (int i = 0; i <5; i++)
            {
              
                char res = GetRandomChar();
                result += res;
               
 
            }
            return result;
            
        }
    }
}
