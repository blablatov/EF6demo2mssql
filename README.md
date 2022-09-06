## EF6demo2mssql
### RU

Демо код для работы с СУБД MSSQL посредством `ORM Entity Framework 6(EF6)`, с использованием парадигмы `Code First`.  
Сценарий `Code First` создает пустую базу данных `AutoLotDB`, в которую добавляет новые демо таблицы с данными пользователей.  
Код включает ядро логики работы с СУБД, по добавлению, обновлению и удалению данных.  

Для включения и работы миграций, из консоли диспетчера пакетов надо выполнить: 

	enable-migrations  -- включение миграций;
	add-migration Initial  -- формирование начальной миграции и повторной;
	update-database   -- обновление базы данных (всегда при добавлении данных);
	add-migration Final -- создание финальной миграции.
	
Для проверки логики работы и формирования таблиц с данными, запустить модуль:  

	AutoLotTestDrive.exe
	
В СУБД mssql появится БД `AutoLotDB`, с таблицами данных: `CreditRisks, Customers, Inventory, Orders`.
В таблице `__MigrationHistory` сохраняются служебные данные о выполненных миграциях.  
	

### EN

Demo code for working with MSSQL DBMS using `ORM Entity Framework 6(EF6)`, via the `Code First` paradigm.  
The `Code First` script creates an empty `AutoLotDB` database and adds new demo tables with user data to it.  
The code contains the core of the logic for working with the DBMS, for adding, updating and deleting data.  

To enable and work migrations, from the package manager console you need to execute:

	enable-migrations -- enable migrations;  
	add-migration Initial -- formation of initial migration and repeated;  
	update-database -- update the database (always when adding data);  
	add-migration Final -- create a final migration.  

To check the logic of work and form tables with data, run the module:  

	AutoLotTestDrive.exe

The `AutoLotDB` database will appear in the mssql DBMS, with data tables: `CreditRisks, Customers, Inventory, Orders`.
The `__MigrationHistory` table stores service data about completed migrations.		
		
		
	
