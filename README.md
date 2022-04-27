# MySQL Unity
Getting MySQL to work with Unity using ODBC or the MySQL .Net Connector plugin.

The ODBC and MySQL .Net Connector Plugins have been tested with a local MAMP server.

If you can, try and setup a REST API that can perform your CRUD operations on your Database for you.
Then use UnityWebRequest to connect your Project to your Database via the REST API.

# Understanding the Issue
To understand the issue, please read the answer given by [peacemaker](https://answers.unity.com/questions/1785533/unity-and-mysql-connector.html).

# Included in this Project
I have included the required MySQL .Net Connector Plugins for Unity 2021.3 (v4.5.2 and v4.8) <br/>
and Unity 2020.3.30 (v4.5) as well as 2 example scripts that can be used to test a connection to your MySQL Database. <br/>

**I have tested this Project with local MAMP server.**

## Plugins
Please delete the already extracted v4.5 plugin if you wish to use an updated version of the plugin.

For Unity 2020.3 and Possibly Older version of Unity extract the following version of the MySQL .Net Connector Plugin
- Plugins
  - MySQL
    - Unity-2020
      - v4.5

For Unity 2021.3 and Possibly Newer versions of Unity extract the following version of the MySQL .Net Connector Plugin
- Plugin
  - MySQL
    - Unity-2020
      - v4.5, or
    - Unity-2021
        - v4.5.2, or
        - v4.8
    

## Scripts
The Project also includes 2 examples found in the Scripts folder.
   - MySQL
     - DatabaseManager.cs
   - ODBC
     - DatabaseManager.cs

# Manual Setup for Unity
## Setup - ODBC
1. Download ODBC Driver [here](https://dev.mysql.com/downloads/connector/odbc/).
2. Install the ODBC Driver.
3. Find the ODBC Driver name
   1. Open Start Menu
   2. Search for Administrator Tools
   3. Open ODBC Data Sources 64bit
   4. Click Add
   5. Copy the Driver name of the Driver that you see, for example mine says “MySQL ODBC 8.0 Unicode Driver”
4. Using MAMP, XAMPP, MySQL Server or whatever MySQL instance you have available
   1. Create a Database called test
   2. Create a Table in that Database, name if whatever you want.
5. Open Unity
   1. Create a Script called DatabaseManager
   2. Overwrite it with the following code - **update the script with your connection information**
   3. For connection examples please have a look [here](https://dev.mysql.com/doc/connector-odbc/en/connector-odbc-examples-programming-net-csharp.html)

       ```csharp
       public class DatabaseManager : MonoBehaviour
       {
           #region VARIABLES
       
           [Header("Connection Properties")]
           public string Host = "localhost";
           public string Port = "3306";
           public string User = "root";
           public string Password = "root";
           public string Database = "test";
       
           #endregion
       
           #region UNITY METHODS
       
           private void Start()
           {
               Connect();
           }
       
           #endregion
       
           #region METHODS
       
           private void Connect()
           {
               try
               {
                   string connectionString = "DRIVER={MySQL ODBC 8.0 Unicode Driver};" +
                                             $"SERVER={Host};" +
                                             $"PORT={Port};" +
                                             $"DATABASE={Database};" +
                                             $"UID={User};" +
                                             $"PWD={Password};";
                   using (OdbcConnection connection = new OdbcConnection(connectionString))
                   {
                       connection.Open();
                       print("ODBC - Opened Connection");
                   }
               }
               catch (OdbcException exception)
               {
                   print(exception.Message);
               }
           }
       
           #endregion
       }
       ```

   4. Attach the script to an Object.
   5. Press Play, you should get a log message that says “Open Connection”.
6. Start Scripting your SQL Queries


## Setup - MySQL .NET Connector Plugin
### Notes
- For Unity 2021.3 the working and tested version for the MySQL .Net Connector Plugin is v8.0.28
- From the tests that I have done, it seems like newer versions of Unity support older versions of the .Net Connector Plugin (v6.9.11).
   - The versions of the .Net Connector Plugin that was tested in Unity 2021.3 was v4.5, v4.5.2 and v4.8, all 3 work!
     - MySQL .Net Connector Plugin v6.9.11
       - Extract v4.x - delete everything except the MySql.Data.dll file
     - MySQL .Net Connector Plugin v8.0.28
       - Extract v4.5.2 - delete the MySql.Data.EntityFrameWork.dll and .xml including the MySql.Web.dll and .xml files
       - Extract v4.8 - delete the MySql.Web.dll and .xml files


- For Unity 2020.3.30 and possibly older (until LTS 2019), the working and tested version for MySQL .Net Connector Plugin is v6.9.11
   - The .Net plugin that was tested in Unity 2020.3.30 was v4.0 and v4.5, both work!
      - Extract v4.x - delete everything except the MySql.Data.dll file


- If the MySQL plugin v6.9.11 does not work for your version of Unity (older than Unity 2020), <br/> 
then download an older version of the MySQL .Net Connector Plugin.<br/>
Try v6.9.5 as suggested in the Unity answer under the heading [Understanding the Issue](https://answers.unity.com/questions/1785533/unity-and-mysql-connector.html).

### Setup
1. Find the .NET Connector Plugin [here](https://downloads.mysql.com/archives/c-net/)
2. Choose .Net & Mono for Operating System.
3. For Unity 2020.3.30 and possibly older versions 
   1. Download v6.9.11 or v6.9.5 (as suggested by [peacemaker](https://answers.unity.com/questions/1785533/unity-and-mysql-connector.html))
4. For Unity 2021.3 and possibly newer versions
   1. Download v8.0.28

#### Unity 2020.3 and Older
1. Navigate to the zip you downloaded **v6.9.11** or **v6.9.5**
   1. Extract the 4.0 or 4.5 folder
   2. Open the folder you extracted and Delete all the plugins except MySql.Data.dll
   3. Open Unity
      1. Go to Project Settings, Player, Other Settings, and Change the API Compatibility Level to .Net Framework 4.x
      2. Create a Plugins folder in Unity
      3. Drag and Drop the 4.0 or 4.5 folder you extracted into the Plugins folder

#### Unity 2021.3 and Newer
1. Navigate to the zip you downloaded v8.0.28
   1. Extract the 4.5.2 or the 4.8 folder
   2. Open the Folder you extracted and Delete the MySql.Data.EntityFramework.dll, MySql.Data.EntityFramework.xml and the MySql.Web.dll and MySql.Web.xml files
   3. Open Unity
      1. Go to Project Settings, Player, Other Settings, and Change the API Compatibility Level to .Net Framework 4.x
      2. Create a Plugins Folder in Unity
      3. Drag and Drop the 4.5.2 or the 4.8 folder you extracted into the Plugins folder

#### Open Unity
   1. If you did not change the API Compatibility Level to .Net Framework 4.x please do so
   2. If you did not Create a Plugins folder, create it
   3. If you did not Drag and Drop the folder you extracted into the Plugins folder, please do so
   4. Create a Script called DatabaseManager
   5. Overwrite the default code with the Following script - **update the script with your connection information**
   6. For connection examples please have a look [here](https://dev.mysql.com/doc/connector-net/en/connector-net-connections-string.html) or [here](https://dev.mysql.com/doc/connector-net/en/connector-net-programming.html)

       ```csharp
       using MySql.Data.MySqlClient;
       using UnityEngine;
       
       public class DatabaseManager : MonoBehaviour
       {
           #region VARIABLES
       
           [Header("Database Properties")]
           public string Host = "localhost";
           public string User = "root";
           public string Password = "root";
           public string Database = "test";
       
           #endregion
       
           #region UNITY METHODS
       
           private void Start()
           {
               Connect();
           }
       
           #endregion
       
           #region METHODS
       
           private void Connect()
           {
               MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
               builder.Server = Host;
               builder.UserID = User;
               builder.Password = Password;
               builder.Database = Database;
       
               try
               {
                   using (MySqlConnection connection = new MySqlConnection(builder.ToString()))
                   {
                       connection.Open();
                       print("MySQL - Opened Connection");
                   }
               }
               catch (MySqlException exception)
               {
                   print(exception.Message);
               }
           }
       
           #endregion
       }
       ```

   7. Attach the script to an Object
   8. Press Play, you should get a message that says “Opened Connection”. 
   9. Start scripting your SQL Queries.