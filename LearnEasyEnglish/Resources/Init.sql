Create Table Users(id Bigint Generated Always as Identity Primary Key,
				  first_name Varchar(50) Not Null,
				  last_name Varchar(50) Not Null,
				  email Varchar(64),
				  phone_number Varchar(15),
				  username Varchar(50) Not Null unique,
				  password_hash text Not Null,
				  salt text Not Null,
				  created_at Timestamp Without Time Zone default now())

Create Table User_Groups_MM(user_id bigint references Users(id),
							groups_id bigint references Words_Groups(id),
						    Primary Key (user_id,groups_id))
			  			

Create Table Words_Groups(id Bigint Generated Always as Identity Primary Key,
				  group_name Varchar(50) Not Null,
				  description text,
				  created_at Timestamp Without Time Zone default now(),
				  updated_at Timestamp Without Time Zone default now())

Create Table Groups_Word_MM(groups_id Bigint references Words_Groups(id),
							word_id Bigint references Words(id),
							created_at Timestamp Without Time Zone default now(),
				  			updated_at Timestamp Without Time Zone default now(),
						    Primary Key (groups_id,word_id))
			  			

Create Table Words(id Bigint Generated Always as Identity Primary Key,
				  word text Not Null,
				  is_have_Defenation boolean Not Null,
				  sound_path text,
				  image_path text,
				  created_at Timestamp Without Time Zone default now())
				  
Create Table Defenations(id Bigint Generated Always as Identity Primary Key,
				  word_id Bigint references Words(id),
				  defenation text,
				  created_at Timestamp Without Time Zone default now())
			  			

Create Table Results(id Bigint Generated Always as Identity Primary Key,
				  user_id Bigint references Users(id),
				  group_id Bigint references Words_Groups(id),
				  description text,
				  created_at Timestamp Without Time Zone default now())
Create Table Results_word(id Bigint Generated Always as Identity Primary Key,
				  result_id Bigint references Results(id),
				  word text Not Null,
				  true_percentage smallint Not Null,
				  created_at Timestamp Without Time Zone default now())
ALTER TABLE Results_word ADD COLUMN updated_at Timestamp Without Time Zone default now();
