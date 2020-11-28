using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AcessarSite
{
    public partial class Index : System.Web.UI.Page
    {
        public static List<Acao> Lista_Acoes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return; 
            Cal_Compra.SelectedDate = DateTime.Now;
        }

        protected void Btn_AcessaSite_Click(object sender, EventArgs e)
        {
            BuscaAcoes(DataParaSegundos(Tb_Data_Compra.Text), DataParaSegundos(Tb_Data_Final.Text));
        }

        public void BuscaAcoes(string dataInicial, string dataFinal)
        {
            if (Convert.ToDouble(dataFinal) < Convert.ToDouble(dataInicial)) return;
            string json;
            using (WebClient webClient = new WebClient())
            {
                json = webClient.DownloadString("https://query1.finance.yahoo.com/v8/finance/chart/PETR3.SA?period1=" + dataInicial + "&period2=" + dataFinal + "&interval=1d");
            }
            LendoJSON(json);
        }

        public class Acao
        {
            public double Data { get; set; }
            public double Preco { get; set; }
        }
        public void LendoJSON(string json)
        {
            JObject jObject = JObject.Parse(json);
            int qtd_acoes = jObject["chart"]["result"].ToArray()[0]["timestamp"].Count();
            Acao acao;
            Lista_Acoes = new List<Acao>();
            for (int i = 0; i < qtd_acoes; i++)
            {//lista com par: data e o valor
                acao = new Acao();
                acao.Data = Convert.ToDouble(jObject["chart"]["result"].ToArray()[0]["timestamp"][i]);
                acao.Preco = Convert.ToDouble(jObject["chart"]["result"].ToArray()[0]["indicators"]["quote"].ToArray()[0]["close"][i]);
                Lista_Acoes.Add(acao);
                //Debug.WriteLine(jObject["chart"]["result"].ToArray()[0]["timestamp"][i]);
            }
            DataTable dataTable = new DataTable();
            DataRow dataRow = null;
            dataTable.Columns.Add("Data");
            dataTable.Columns.Add("Preço");
            for (int i = 0; i < Lista_Acoes.Count; i++)
            {
                dataRow = dataTable.NewRow();
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        dataRow["Data"] = SegundosParaData(Lista_Acoes[i].Data);
                    }
                    else
                    {
                        dataRow["Preço"] = Lista_Acoes[i].Preco.ToString();
                    }
                }
                dataTable.Rows.Add(dataRow);
            }
            Grid_Precos.DataSource = dataTable;
            Grid_Precos.DataBind();
        }

        public string SegundosParaData(double segundos)
        {
            DateTime data = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return data.AddSeconds(segundos).ToShortDateString();
        }

        public string DataParaSegundos(string data)
        {
            TimeSpan timeSpan = Convert.ToDateTime(data) - new DateTime(1970, 1, 1);
            int resultado = (int)timeSpan.TotalSeconds;
            return resultado.ToString();
        }

        protected void Cal_Compra_SelectionChanged(object sender, EventArgs e)
        {
            Label1.Text = Cal_Compra.SelectedDate.ToString();
        }

        protected void Tb_Data_Compra_TextChanged(object sender, EventArgs e)
        {
            Label2.Text = Tb_Data_Compra.Text;
        }

        protected void Tb_Data_Final_TextChanged(object sender, EventArgs e)
        {

        }
    }
}