using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FragtSource {
    public class Print {
        public void Printall(List<Package> packages, int gLSTotal, int uOmdelingTotal, int mOmdelingTotal, int brevTotal) {

            string path = @Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Print.csv";
            TryToDelete(path);

            string appendText1 = "sep=;" + Environment.NewLine + "Dato;Type;Pris;Land;Kommentar" + Environment.NewLine;
            File.AppendAllText(path, appendText1, Encoding.UTF8);

            foreach (Package package in packages) {
                string appendText = package.Date.ToString("dd/MM/yyyy") + ";" + package.Type.ToString() + ";" + package.Price.ToString() + ";" + package.Country.ToString() + ";" + package.Comment + Environment.NewLine;
                File.AppendAllText(path, appendText, Encoding.UTF8);
            }
            string appendText2 = Environment.NewLine + "GLS:;MOmdeling:;UOmdeling:;Brev:";
            File.AppendAllText(path, appendText2, Encoding.UTF8);

            string appendText3 = Environment.NewLine + $"{gLSTotal};{mOmdelingTotal};{uOmdelingTotal};{brevTotal}";
            File.AppendAllText(path, appendText3, Encoding.UTF8);
        }

        private void TryToDelete(string path) {
            try {
                File.Delete(path);
            } catch {

            }
        }
    }
}
