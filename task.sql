 create database ctrltask;
 go
 use ctrltask;
 go
 create table userdata
 (
	u_id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	u_name varchar(50) not null,
	u_email varchar(255) not null,
	u_password varchar(20) not null,
	img nvarchar(MAX)
 );
  go

 create table project
 (
	p_id int not null primary key identity(1,1), 
	u_id int not null,
	p_name varchar(35) not null,
	number_of_tasks int DEFAULT 0,
	p_done bit default 0,
	foreign key(u_id) references userdata(u_id)
 );
 go

 create table task
(
	t_id int not null primary key identity(1,1),
	p_id int not null,
	t_name varchar(35) not null,
	content varchar(250),
	date_time_created DATETIME DEFAULT CURRENT_TIMESTAMP,
	date_time_finish Datetime default 0,
	t_status int default 0,
	t_done bit default 0,
	CONSTRAINT t_status CHECK (t_status BETWEEN 0 AND 4),
	foreign key(p_id) REFERENCES project(p_id), 
);
 go

create table bridge_task_userdata
(
	u_id int not null ,
	t_id int not null,
	foreign key(u_id) references userdata(u_id),
	foreign key(t_id) references task(t_id),
	primary key(u_id, t_id)
);
 go


/*
insert into userdata values( 'Arwa', 'rdfasd@gmail.com', '3232');
insert into project values('Network', 1, 2);
insert into task values(1, 'task', 'sadsadasfads', '2008-11-11', '2008-11-11', 3);
insert into bridge_task_userdata values(1,1);insert into userdata values( 'Arwa', 'rdfasd@gmail.com', '3232');
insert into project values('Network', 1, 2);
insert into task values(1, 'task', 'sadsadasfads', '2008-11-11', '2008-11-11', 3);
select * from userdata;
select * from userdata;
insert into bridge_task_userdata values(1,1);*/