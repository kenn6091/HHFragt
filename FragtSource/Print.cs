using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FragtSource {
    public class Print {
        public void Printall(List<Package> packages) {

            string path = @Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Print.csv";
            TryToDelete(path);

            string appendText1 = "sep=;" + Environment.NewLine + "Dato;Type;Pris;Land;Kommentar" + Environment.NewLine;
            File.AppendAllText(path, appendText1, Encoding.UTF8);

            foreach (Package package in packages) {
                string appendText = package.Date.ToString("dd/MM/yyyy") + ";" + package.Type.ToString() + ";" + package.Price.ToString() + ";" + package.Country.ToString() + ";" + package.Comment + Environment.NewLine;
                File.AppendAllText(path, appendText, Encoding.UTF8);
            }
        }

        private void TryToDelete(string path) {
            try {
                File.Delete(path);
            } catch {

            }
        }
    }
}
