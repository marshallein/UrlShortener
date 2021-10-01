using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortener
{
    public class RandomURl
    {
        const int URL_LENGTH = 10;
        List<int> rand_number = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        List<char> rand_char = new List<char>(){'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                                                'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B',
                                                'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                                                'Q', 'R', 'S',  'T', 'U', 'V', 'W', 'X', 'Y', 'Z' ,'_','$','-'};
        public String getShortUrl()
        {
            string url = "";

            Random rand = new Random();

            for (int i = 0; i < URL_LENGTH; i++)
            {
                int randomBetweenNumberOrChar = rand.Next(0, 2);
                if (randomBetweenNumberOrChar == 1)
                {
                    int randIndex = rand.Next(0, rand_number.Count);
                    url += rand_number[randIndex].ToString();
                }
                else
                {
                    int randChar = rand.Next(0, rand_char.Count);
                    url += rand_char[randChar].ToString();
                }
            }
            return url;
        }

    }
}
