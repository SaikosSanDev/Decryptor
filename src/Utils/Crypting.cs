using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decryptor.Utils
{
    class Crypting
    {
        private static char[] abc = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
                              'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                              'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                              'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
                              'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                              'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                              '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                              ',', '.', '!', '?', '-', '_', ' ', '{', '}', '(', ')', ';',
                              '\'', '=', '+'};

        private static char[] SaikoC = {')', '0', 'w', 'k', '8', 'A', 'y', 'D',
                                 '+', '5', '=', 'd', 'L', ' ', 'l', 'B',
                                 '-', '?', 'i', '1', 'V', 'Q', 't', '6', '3', ';',
                                 ',', '9', 'v', 'T', 'C', 'N', 'z', 'n',
                                 '}', '4', 'Z', '_', 'P', 'f', 'p', '7',
                                 '\'', 's', 'X', 'S', '.', '2', 'F', 'u', '{', 'J',
                                 '(', 'U', 'O', 'H', 'h', 'o', 'b', 'E', 'm', 'K', 'g', 'r',
                                 'j' , 'a', 'Y', 'G', 'q', 'e', 'R' , '!', 'W', 'c', 'x', 'M', 'I'};

        private static char[] Caesar = {'9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                                     'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's',
                                     't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C',
                                     'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                                     'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W',
                                     'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6',
                                     '7', '8' };

        public static string decryptFromSaikoC(string text)
        {
            char[] content = text.ToCharArray();
            string message = "";
            List<char> temporal = SaikoC.ToList();
            for(int i = 0; i < content.Length;i++)
            {
                if (SaikoC.Contains(content[i]))
                {
                    message += abc[temporal.IndexOf(content[i])];
                }
                else
                {
                    message += content[i];
                }
            }
            return message;
        }

        public static string decryptFromCaeser(string text)
        {
            char[] content = text.ToCharArray();
            string message = "";
            List<char> temporal = Caesar.ToList();
            for (int i = 0; i < content.Length; i++)
            {
                if(Caesar.Contains(content[i]))
                {
                    message += abc[temporal.IndexOf(content[i])];
                }
                else
                {
                    message += content[i];
                }
            }
            return message;
        }

        public static string encryptToSaikoC(string text)
        {
            char[] content = text.ToCharArray();
            string message = "";
            List<char> temporal = abc.ToList();
            for (int i = 0; i < content.Length; i++)
            {
                if (SaikoC.Contains(content[i]))
                {
                    message += SaikoC[temporal.IndexOf(content[i])];
                }
                else
                {
                    message += content[i];
                }
            }
            return message;
        }

        public static string encryptToCaeser(string text)
        {
            char[] content = text.ToCharArray();
            string message = "";
            List<char> temporal = abc.ToList();
            for (int i = 0; i < content.Length; i++)
            {
                if (Caesar.Contains(content[i]))
                {
                    message += Caesar[temporal.IndexOf(content[i])];
                }
                else
                {
                    message += content[i];
                }
            }
            return message;
        }

    }
}
