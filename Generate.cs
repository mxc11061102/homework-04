using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace homework_04
{
    class Generate
    {
        public int left=0;
        public int bottom=0;
        public int top=0;
        public int right=0;
        public char[][] matrix=new char[60][];
        public bool[][] isin=new bool[60][];
        public string[] wordlist=new string[]{};

        public void GetData(string filename){
            FileStream fs = new FileStream(Application.StartupPath + @"\" + filename, FileMode.Open, FileAccess.Read);
            StreamReader m_streamReader = new StreamReader(fs);//设定读写的编码
            //使用StreamReader类来读取文件  
            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            //从数据流中读取每一行，直到文件的最后一行，并在angel.Text中显示出内容
            string strLine=null;
            string words=null;
            do
            {
                strLine = m_streamReader.ReadLine();
                if (strLine != null)
                    if (words == null)
                        words += strLine;
                    else
                        words += (','+strLine);
            }while (strLine != null);
            m_streamReader.Close();    //关闭此StreamReader对象
            words.Trim();
            wordlist = words.Split(',');
        }
        public void SortWord() {
            int length=wordlist.Length;
            for (int i = 0; i < length - 1; i++) {
                bool flag=false;
                for (int j = 0; j < length - 1 - i; j++) {
                    if (wordlist[j].Length < wordlist[j + 1].Length) {
                        string temp = wordlist[j];
                        wordlist[j] = wordlist[j + 1];
                        wordlist[j + 1] = temp;
                        flag = true;
                    }
                }
                if (!flag)
                    break;
            }
        }
        public void Initial() {
            for (int i = 0; i < 60; i++) { 
                matrix[i]=new char[60];
                isin[i]=new bool[60];
                for (int j = 0; j < 60; j++) {
                    matrix[i][j] = '\0';
                    isin[i][j] = false;
                }
            }
        }
        public void Insert_Diagonal_RB(string word)
        {
            int length = word.Length;
            for (int scale = 0; scale <= 60 - length; scale++)
            {
                for (int i = 0; i <= scale;i++ )
                {
                    bool flag = true;
                    int j = scale;
                    if (((i % 2) + (j % 2)) % 2 != 0)
                    {
                        continue;
                        //MessageBox.Show(i + j + "");
                    }
                    for (int k = 0; k < length; k++)
                    {
                        if (isin[i + k][j + k] == true && matrix[i + k][j + k] != word[k])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        for (int k = 0; k < length; k++) {
                            isin[i + k][j + k] = true;
                            matrix[i + k][j + k] = word[k];
                        }
                        //MessageBox.Show(matrix[i][j] + "");
                        if (i < top)
                            top = i;
                        if (j < left)
                            left = j;
                        if (i + length-1 > bottom)
                            bottom = i + length-1;
                        if (j + length-1 > right)
                            right = j + length-1;
                        return;
                    }                    
                }
                //MessageBox.Show(word+scale);
                for (int j = 0;j < scale-1;j++ )
                {
                    bool flag = true;
                    int i = scale;
                    if (((i % 2) + (j % 2)) % 2 != 0)
                        continue;
                    for (int k = 0; k < length; k++)
                    {
                        if (isin[i + k][j + k] == true && matrix[i + k][j + k] != word[k])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        for (int k = 0; k < length; k++)
                        {
                            isin[i + k][j + k] = true;
                            matrix[i + k][j + k] = word[k];
                        }
                        if (i < top)
                            top = i;
                        if (j < left)
                            left = j;
                        if (i + length-1 > bottom)
                            bottom = i + length-1;
                        if (j + length-1 > right)
                            right = j + length-1;
                        return;
                    }
                }
            }
        }
        public void Insert_Diagonal_LB(string word)
        {
            int length = word.Length;
            for (int scale = length-1; scale<60; scale++)
            {
                for (int i = 0; i <= scale; i++)
                {
                    bool flag = true;
                    int j = scale;
                    if (((i % 2) + (j % 2)) % 2 == 0)
                        continue;
                    for (int k = 0; k < length; k++)
                    {
                        if (isin[i + k][j - k] == true && matrix[i + k][j - k] != word[k])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        for (int k = 0; k < length; k++)
                        {
                            isin[i + k][j - k] = true;
                            matrix[i + k][j - k] = word[k];
                        }
                        if (i < top)
                            top = i;
                        if (j-length+1 <left )
                            left = j-length+1;
                        if (i+length-1 >bottom )
                            bottom = i+length-1;
                        if (j > right)
                            right = j;
                        return;
                    }
                }
                for (int j = length; j < scale - 1; j++)
                {
                    bool flag = true;
                    int i = scale;
                    if (((i % 2) + (j % 2)) % 2 == 0)
                        continue;
                    for (int k = 0; k < length; k++)
                    {
                        if (isin[i + k][j - k] == true && matrix[i + k][j - k] != word[k])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        for (int k = 0; k < length; k++)
                        {
                            isin[i + k][j - k] = true;
                            matrix[i + k][j - k] = word[k];
                        }
                        if (i < top)
                            top = i;
                        if (j - length + 1 < left)
                            left = j - length + 1;
                        if (i + length - 1 > bottom)
                            bottom = i + length - 1;
                        if (j > right)
                            right = j;
                        return;
                    }
                }
            }
        }
        public void Insert_Diagonal_RT(string word)
        {
            int length = word.Length;
            for (int scale = 0; scale <= 60-length; scale++)
            {
              
                for (int j = 0; j <= scale; j++)
                {
                    bool flag = true;
                    int i = scale+length-1;
                    if (((i % 2) + (j % 2)) % 2 == 0)
                        continue;
                    for (int k = 0; k < length; k++)
                    {
                        if (isin[i - k][j + k] == true && matrix[i - k][j + k] != word[k])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        for (int k = 0; k < length; k++)
                        {
                            isin[i - k][j + k] = true;
                            matrix[i - k][j + k] = word[k];
                        }
                        if (i - length + 1 < top)
                            top = i - length + 1;
                        if (j < left)
                            left = j;
                        if (i > bottom)
                            bottom = i;
                        if (j + length - 1 > right)
                            right = j + length - 1;
                        return;
                    }
                }
                for (int i = length - 1; i < scale + length-1; i++)
                {
                    bool flag = true;
                    int j = scale + length - 1;
                    if (((i % 2) + (j % 2)) % 2 == 0)
                        continue;
                    for (int k = 0; k < length; k++)
                    {
                        if (isin[i - k][j + k] == true && matrix[i - k][j + k] != word[k])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        for (int k = 0; k < length; k++)
                        {
                            isin[i - k][j + k] = true;
                            matrix[i - k][j + k] = word[k];
                        }
                        if (i - length + 1 < top)
                            top = i - length + 1;
                        if (j < left)
                            left = j;
                        if (i > bottom)
                            bottom = i;
                        if (j + length - 1 > right)
                            right = j + length - 1;
                        return;
                    }
                }
            }
        }
        public void Insert_Diagonal_LT(string word)
        {
            int length = word.Length;
            for (int scale = 0; scale <= 60 - length; scale++)
            {

                for (int j = length-1; j <= scale+length-1; j++)
                {
                    bool flag = true;
                    int i = scale + length - 1;
                    if (((i % 2) + (j % 2)) % 2 != 0)
                        continue;
                    for (int k = 0; k < length; k++)
                    {
                        if (isin[i - k][j - k] == true && matrix[i - k][j - k] != word[k])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        for (int k = 0; k < length; k++)
                        {
                            isin[i - k][j - k] = true;
                            matrix[i - k][j - k] = word[k];
                        }
                        if (i - length + 1 < top)
                            top = i - length + 1;
                        if (j-length-1 < left)
                            left = j-length-1;
                        if (i > bottom)
                            bottom = i;
                        if (j > right)
                            right = j;
                        return;
                    }
                }
                for (int i = length - 1; i < scale + length - 1; i++)
                {
                    bool flag = true;
                    int j = scale + length - 1;
                    if (((i % 2) + (j % 2)) % 2 != 0)
                        continue;
                    for (int k = 0; k < length; k++)
                    {
                        if (isin[i - k][j - k] == true && matrix[i - k][j - k] != word[k])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        for (int k = 0; k < length; k++)
                        {
                            isin[i - k][j - k] = true;
                            matrix[i - k][j - k] = word[k];
                        }
                        if (i - length + 1 < top)
                            top = i - length + 1;
                        if (j - length - 1 < left)
                            left = j - length - 1;
                        if (i > bottom)
                            bottom = i;
                        if (j > right)
                            right = j;
                        return;
                    }
                }
            }
        }
        public void Insert_Diagonal() { 
            int length=wordlist.Length;
            int j = 0;
            for (int i = 0; i < length;) {
                Insert_Diagonal_RB(wordlist[i]);
                if (++i >= length - 8)
                    break;
                Insert_Diagonal_LB(wordlist[i]);
                if (++i >= length - 8)
                    break;
                Insert_Diagonal_RT(wordlist[i]);
                if (++i >= length - 8)
                    break;
                Insert_Diagonal_LT(wordlist[i]);
                if (++i >= length - 8)
                    break;
                j = i;
            }
            MessageBox.Show(wordlist[j]);
        }
        public Generate(string filename) {
            GetData(filename);
            SortWord();
            Initial();
            //MessageBox.Show("asds");
            Insert_Diagonal();
            string ddd = null;
            for (int i = 0; i < wordlist.Length; i++)
                ddd += (wordlist[i] + '\n');
            MessageBox.Show(ddd);
        }
    }
}
