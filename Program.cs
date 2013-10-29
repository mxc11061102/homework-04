using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace homework_04
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] argv)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Generate gen = new Generate(argv[0]);
            Form1 form;
            if (argv.Length > 1)
            {
                form = new Form1(gen.matrix,gen.isin,true);
            }
            else
            {
                form = new Form1(gen.matrix,gen.isin,false); 
            }
            Application.Run(form);
        }
    }
}
