using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DBAS_GroupProject
{
    /// <summary>
    /// Interaction logic for Patient_Dashboard.xaml
    /// </summary>
    public partial class Patient_Dashboard : Window
    {
        public Patient_Dashboard()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectString = Properties.Settings.Default.ConnectionString;
            SqliteConnection sqliteCon = new SqliteConnection(connectString);

        }
    }

    public void PatientData()
    {
        string connectString = Properties.Settings.Default.ConnectionString;
        SqliteConnection sqliteCon = new SqliteConnection(connectString);

        sqliteCon.Open();
        string Query = "EXEC Physician_Patient_Dashboard ";
        SqliteCommand createCommand = new SqliteCommand(Query, sqliteCon);
        createCommand.ExecuteNonQuery();

        SqliteDataAdapter dataAdp = new SqliteDataAdapter(createCommand);
        DataTable dt = new DataTable("roominfor");
        dataAdp.Fill(dt);
        labelRoomTotal.ItemsSource = dt.DefaultView;
        dataAdp.Update(dt);
        sqliteCon.Close();




    }
}
