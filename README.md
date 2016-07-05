##**Template-based DB Document Generator for SQL Server**

# Overview
We always waste time to make database document, especially when we are developing, it's no time to keep document and database staying on the same page. For that reason I made a small tool to automatically generate document base on database & template file, hope it make people happy with making their own style database document in a second.

#Feature

0. Auto generate database document (table list and column info)
0. Preview column information as your reference
0. Remember the tables you selected for each connection
0. Template-based document format (customize your own format & style)

#Tutorial

You can simply click reload button to load all tables. When you click any table in this table list, column information will show up on the right side. It provides you a simple way to check out those information. After pressing the "Generate document" button, the document will be automatically generated for those tables you checked in a second. It sounds great, eh? 

![Main](/img/01 MainFrm.png)

1. Reload all tables from database via current connection
2. Check all tables in list
3. Uncheck all tables in list
4. Remember checked tables for current connection
5. Generate document for checked tables and open it 
6. Setting (choose connection & document template)


#Setting

In the setting form, you can maintain connections and decide which one you want to use to generate document. As we mentioned above, it's a template-based database document generator, so we can choose our own template here as well.

![Main](/img/02 SettingFrm.png)

1. Add / Remove / Select connection string
2. Export / Add / Remove / Select document template
3. Save settings to config file

#Template File

I provide a default template to show you how to customize your own document. In #TableListTemplate sheet, you can change everything like header text, font, background color and columns but splitting one table's tags into multiple rows. That's the only rule you need to follow.

 

[Template for table list]

![Main](/img/03 TableTemplate.png)

In #TableSchemaTemplate sheet, you can change everything like removing some columns which you don't need as well but remember keep the simple rule "Do not split one column's tags into multiple rows" for each column. Otherwise, you can put #table.name, #table.description and #table.type tag to somewhere you want to show up.

[Template for column info.]

![Main](/img/04 ColumnTemplate.png)


#Result
After the file is generated, it will be opened automatically and the format just like the template you design.

[table list sheet]

![Main](/img/05 TableResult.png)

[column list sheet]

![Main](/img/06 ColumnResult.png)

#Acknowledgement

Thanks [Astah](http://astah.net/) inspired me to create the template-based document idea.