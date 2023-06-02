using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BLL
{
    public class Language
    {
        private string _unicodeString;

        public string unicodeString
        {
            get { return _unicodeString; }
            set { _unicodeString = value; }
        }

        private string _PlainText;

        public string PlainText
        {
            get { return _PlainText; }
            set { _PlainText = value; }
        }

        private string _TempText;

        public string TempText
        {
            get { return _TempText; }
            set { _TempText = value; }
        }

        private string _ResultText;

        public string ResultText
        {
            get { return _ResultText; }
            set { _ResultText = value; }
        }


        public string ExportToShrutiFont(string pPlainText)
        {
            try
            {
                _PlainText = pPlainText;
                this.unicodeString = "";
                string str = "";
                string str2 = "";
                string nonUChar = "";
                for (int i = 0; i < _PlainText.Length; i++)
                {
                    nonUChar = _PlainText.Substring(i, 1).ToString();
                    switch (nonUChar)
                    {
                        case "l":
                            {
                                str2 = "િ";
                                continue;
                            }
                        case "\"":
                            {
                                _TempText = this.unicodeString;
                                string str4 = _TempText.Substring(0, _TempText.Length - 1);
                                this.unicodeString = str4 + "ર્" + _TempText.Substring(_TempText.Length - 1, 1);
                                continue;
                            }
                        case "F":
                            _TempText = this.unicodeString;
                            if (_TempText.Length > 0)
                            {
                                if (_TempText.Length == 1)
                                {
                                    if (_TempText == "અ")
                                    {
                                        this.unicodeString = "આ";
                                        continue;
                                    }
                                }
                                else if (_TempText.Substring(_TempText.Length - 1) == "અ")
                                {
                                    this.unicodeString = _TempText.Substring(0, _TempText.Length - 1) + "આ";
                                    continue;
                                }
                            }
                            break;

                        case "[":
                            _TempText = this.unicodeString;
                            if (_TempText.Length > 0)
                            {
                                if (_TempText.Length == 1)
                                {
                                    if (_TempText == "અ")
                                    {
                                        this.unicodeString = "એ";
                                        continue;
                                    }
                                }
                                else
                                {
                                    if (_TempText.Substring(_TempText.Length - 1) == "અ")
                                    {
                                        this.unicodeString = _TempText.Substring(0, _TempText.Length - 1) + "એ";
                                        continue;
                                    }
                                    if (_TempText.Substring(_TempText.Length - 1) == "ા")
                                    {
                                        this.unicodeString = _TempText.Substring(0, _TempText.Length - 1) + "ો";
                                        continue;
                                    }
                                }
                            }
                            break;

                        case "M":
                            _TempText = this.unicodeString;
                            if (_TempText.Length > 0)
                            {
                                if (_TempText.Length == 1)
                                {
                                    if (_TempText == "અ")
                                    {
                                        this.unicodeString = "ઓ";
                                        continue;
                                    }
                                }
                                else if (_TempText.Substring(_TempText.Length - 1) == "અ")
                                {
                                    this.unicodeString = _TempText.Substring(0, _TempText.Length - 1) + "ઓ";
                                    continue;
                                }
                            }
                            break;

                        case "{":
                            _TempText = this.unicodeString;
                            if (_TempText.Length > 0)
                            {
                                if (_TempText.Length == 1)
                                {
                                    if (_TempText == "અ")
                                    {
                                        this.unicodeString = "ઐ";
                                        continue;
                                    }
                                    if (_TempText == "આ")
                                    {
                                        this.unicodeString = "ઔ";
                                        continue;
                                    }
                                }
                                else
                                {
                                    if (_TempText.Substring(_TempText.Length - 1) == "અ")
                                    {
                                        this.unicodeString = _TempText.Substring(0, _TempText.Length - 1) + "ઐ";
                                        continue;
                                    }
                                    if (_TempText.Substring(_TempText.Length - 1) == "ા")
                                    {
                                        this.unicodeString = _TempText.Substring(0, _TempText.Length - 1) + "ૌ";
                                        continue;
                                    }
                                    if (_TempText.Substring(_TempText.Length - 1) == "આ")
                                    {
                                        this.unicodeString = _TempText.Substring(0, _TempText.Length - 1) + "ઔ";
                                        continue;
                                    }
                                }
                            }
                            break;
                    }
                    str = this.getUnicodeForChar(nonUChar);
                    this.unicodeString = this.unicodeString + str + str2;
                    str2 = "";
                    str = "";
                }
                _ResultText = this.unicodeString;
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry, an error occurred !");
            }
            return _ResultText;
        }

        public string ExportNumberToShrutiFont(string pPlainText)
        {
            this.unicodeString = "";
            string nonUChar = "";
            for (int i = 0; i < pPlainText.Length; i++)
            {
                nonUChar = pPlainText.Substring(i, 1).ToString();
                string str = this.getUnicodeForNumber(nonUChar);
                this.unicodeString = this.unicodeString + str;
            }
            _ResultText = this.unicodeString;
            return _ResultText;
        }


        private string getUnicodeForChar(string nonUChar)
        {
            switch (nonUChar)
            {
                case "a":
                    return "બ્";

                case "b":
                    return "ખ્";

                case "c":
                    return "'";

                case "d":
                    return "મ્";

                case "e":
                    return "ભ્";

                case "f":
                    return ")";

                case "g":
                    return "ન્";

                case "h":
                    return "ઝ";

                case "i":
                    return "ય્";

                case "j":
                    return "વ્";

                case "k":
                    return "ઋ";

                case "l":
                    return "િ";

                case "m":
                    return "?";

                case "n":
                    return "દ્ય";

                case "o":
                    return ":";

                case "p":
                    return "ઉ";

                case "q":
                    return "/";

                case "r":
                    return "ચ્";

                case "s":
                    return "(";

                case "t":
                    return "ત્";

                case "u":
                    return "ગ્";

                case "v":
                    return "-";

                case "w":
                    return "ધ્";

                case "x":
                    return "શ્";

                case "y":
                    return "થ્";

                case "z":
                    return "શ્ર";

                case "A":
                    return "બ";

                case "B":
                    return "ખ";

                case "C":
                    return "હ";

                case "D":
                    return "મ";

                case "E":
                    return "ભ";

                case "F":
                    return "ા";

                case "G":
                    return "ન";

                case "H":
                    return "જ";

                case "I":
                    return "ય";

                case "J":
                    return "વ";

                case "K":
                    return "છ";

                case "L":
                    return "ી";

                case "M":
                    return "ો";

                case "N":
                    return "દ";

                case "O":
                    return "ફ";

                case "P":
                    return ".";

                //case "QF":
                //    return "ષ્";

                case "Q":
                    return "ષ્";

                case "R":
                    return "ચ";

                case "S":
                    return "ક";

                case "T":
                    return "ત";

                case "U":
                    return "ગ";

                case "V":
                    return "અ";

                case "W":
                    return "ધ";

                case "X":
                    return "શ";

                case "Y":
                    return "થ";

                case "Z":
                    return "ર";

                //case "1F":
                //    return "ક્ષ";

                case "1":
                    return "ક્ષ";

                case "2":
                    return "\x00d7";

                case "3":
                    return "ઘ";

                case "4":
                    return ",";

                case "5":
                    return "પ";

                case "6":
                    return "ણ";

                case "7":
                    return "જ્ઞ";

                case "8":
                    return "ટ";

                case "9":
                    return "ઠ";

                case "0":
                    return "ડ";

                case "-":
                    return "ઢ";

                case "=":
                    return "્ર";

                case "`":
                    return "શ્";

                case "~":
                    return "રૂ";

                case "!":
                    return "૧";

                case "@":
                    return "%";

                case "#":
                    return "૩";

                case "$":
                    return "૪";

                case "%":
                    return "પ્";

                case "^":
                    return "ણ્";

                case "&":
                    return "૬";

                case "*":
                    return "૭";

                case "(":
                    return "૮";

                case ")":
                    return "૯";

                case "_":
                    return "૦";

                case "+":
                    return "ત્ર";

                case "[":
                    return "ે";

                case "{":
                    return "ૈ";

                case "]":
                    return "ુ";

                case "}":
                    return "ૂ";

                case ";":
                    return "સ";

                case ":":
                    return "સ્";

                case "'":
                    return "ૃ";

                case "\"":
                    return "ર્";

                case @"\":
                    return "ં";

                case "|":
                    return "્ર";

                case "/":
                    return "ળ";

                case "?":
                    return "ળ્";

                case ".":
                    return "ઈ";

                case ">":
                    return "ઇ";

                case ",":
                    return "લ";

                case "<":
                    return "લ્";

                case "\x00a1":
                    return "દ્દ";

                case "\x00a2":
                    return "ઙ";

                case "\x00a3":
                    return "દ્વ";

                case "\x00a4":
                    return "ક્લ";

                case "\x00a5":
                    return "ઁ";

                case "\x00a7":
                    return "દ્ર";

                case "\x00a8":
                    return "ઝ્ર";

                case "\x00a9":
                    return "ક્ષ્";

                case "\x00aa":
                    return "ણુ";

                case "\x00ab":
                    return "જ્ર";

                case "\x00ae":
                    return "ઈ";

                case "\x00b1":
                    return "જ્ઞ્ય";

                case "\x00b4":
                    return "+";

                case "\x00b5":
                    return "ઊ";

                case "\x00b6":
                    return "ૅ";

                case "\x00b8":
                    return ";";

                case "\x00ba":
                    return "પ્ત";

                case "\x00bb":
                    return "ડ્ડ";

                case "\x00bd":
                    return "ખ્ત";

                case "\x00bf":
                    return "ત્ત";

                case "\x00c0":
                    return "ત્ત્ય";

                case "\x00c1":
                    return "ૌ";

                case "\x00c2":
                    return "િ";

                case "\x00c3":
                    return "િ";

                case "\x00c4":
                    return "ી";

                case "\x00c5":
                    return "ઁ";

                case "\x00c6":
                    return "શ્ન";

                case "\x00c7":
                    return "શ્ર";

                case "\x00c8":
                    return "ત્ર્ય";

                case "\x00c9":
                    return "ક્ત";

                case "\x00ca":
                    return "ક્ર";

                case "\x00cb":
                    return "ફ્ર";

                case "\x00cc":
                    return "ક્ર";

                case "\x00cd":
                    return "દ્મ";

                case "\x00ce":
                    return "ટ્ટ";

                case "\x00cf":
                    return "દ્રૃ";

                case "\x00d0":
                    return "ૡ";

                case "\x00d1":
                    return "લ્ટ";

                case "\x00d3":
                    return "ક્ષ્ય";

                case "\x00d4":
                    return "જા";

                case "\x00d5":
                    return "ુ";

                case "\x00d6":
                    return "ૂ";

                case "\x00d8":
                    return "ષ";

                case "\x00d9":
                    return "ક્ષ";

                case "\x00da":
                    return "ષ્ટ";

                case "\x00db":
                    return "દ્દ";

                case "\x00dc":
                    return "ઝ્ર";

                case "\x00de":
                    return "ક્ક";

                case "\x00df":
                    return "જ્";

                case "\x00e0":
                    return "સ્ત્ર";

                case "\x00e1":
                    return "卐";

                case "\x00e2":
                    return "દ્ઘ";

                case "\x00e3":
                    return "દ્ર";

                case "\x00e4":
                    return "દ્વ";

                case "\x00e5":
                    return "દ્બ";

                case "\x00e6":
                    return "હ્ય";

                case "\x00e7":
                    return "ઈં";

                case "\x00e8":
                    return "ઇં";

                case "\x00e9":
                    return "ઊ";

                case "\x00ea":
                    return "ઊં";

                case "\x00eb":
                    return "ઉં";

                case "\x00ec":
                    return "હ્ર";

                case "\x00ed":
                    return "હ્લ";

                case "\x00ee":
                    return "હ્ન";

                case "\x00ef":
                    return "હ્મ";

                case "\x00f0":
                    return "હ્વ";

                case "\x00f1":
                    return "હ્ર";

                case "\x00f2":
                    return "[";

                case "\x00f3":
                    return "]";

                case "\x00f4":
                    return "ઢ્ઢ";

                case "\x00f5":
                    return "ઠ્ઠ";

                case "\x00f6":
                    return "ઙ્ખ";

                case "\x00f8":
                    return "ડ્ઢ";

                case "\x00f9":
                    return "ઙ્ગ";

                case "\x00fa":
                    return "ઙ્મ";

                case "\x00fb":
                    return "ઙ્ઘ";

                case "\x00fc":
                    return "શ્ચ";

                case "\x00fe":
                    return "ન્ન";

                case "\x00D2":
                    return "જી";


                //eXTRA

                case "\x00B0":
                    return "ર";

                case "\x00DD":
                    return "પ્ર";



                // eNDEXTRA

                case "œ":
                    return "ત્ર્";

                case "š":
                    return "જ્ઞ્";

                case "Ÿ":
                    return "્";

                case "ˆ":
                    return "’";

                case "ˉ":
                    return "ૃ";

                case "—":
                    return "’";

                case "›":
                    return "ૐ";

                case "∙":
                    return "*";
            }
            return nonUChar;
        }

        private string getUnicodeForNumber(string nonUChar)
        {
            switch (nonUChar)
            {
                case "0":
                    return "૦";
                case "1":
                    return "૧";
                case "2":
                    return "૨";
                case "3":
                    return "૩";
                case "4":
                    return "૪";
                case "5":
                    return "૫";
                case "6":
                    return "૬";
                case "7":
                    return "૭";
                case "8":
                    return "૮";
                case "9":
                    return "૯";
            }
            return nonUChar;

        }
    }
}
