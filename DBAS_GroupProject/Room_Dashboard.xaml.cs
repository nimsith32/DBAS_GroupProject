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
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.Sqlite;


namespace DBAS_GroupProject
{
    /// <summary>
    /// Interaction logic for Room_Dashboard.xaml
    /// </summary>
    public partial class Room_Dashboard : Window
    {

        public Room_Dashboard()
        {
            InitializeComponent();
        }
    }

    public void InsertData( )
    {
        string connectString = Properties.Settings.Default.ConnectionString;
        SqliteConnection sqliteCon = new SqliteConnection(connectString);

        sqliteCon.Open();
        string Query = "EXEC Room_Total ";
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
