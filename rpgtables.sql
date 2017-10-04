--DROP TABLE entity_inventory;
--DROP TABLE player;
--DROP TABLE store;
--DROP TABLE inventory;
--DROP TABLE nonHuman;

CREATE TABLE player
(
	player_id		int				primary key			identity(1,1),
	name			varchar(50)		not null,
	life			int				not null,
	gender			varchar(1)		not null,
	xp				int				not null,
	strength		int				not null,
	attack			int				not null,
	defense			int				not null,
	magic			int				not null,
	xpLevel			int				not null,
	gold			int				not null,
	playertype		varchar(50)		not null,
	CONSTRAINT ck_gender CHECK(gender IN ('M','F'))
);

CREATE TABLE inventory
(
	inventory_id	int				primary key			identity(1,1),
	name			varchar(50)		not null,
	type			varchar(50)		not null,
	subType			varchar(50)		null,
	weight			decimal			not null,
	strengthProp	int				not null,
	attackProp		int				not null,
	defenseProp		int				not null,
	magicProp		int				not null,
	CONSTRAINT uq_inventory unique (name)
);

CREATE TABLE store
(
	store_id		int				primary key			identity(1,1),
	name			varchar(50)		not null,
	location		varchar(50)		not null,
	type			varchar(50)		not null,
	gold			int				not null,
	storeLevel		int				not null,
	CONSTRAINT uq_name_location unique(name, location)
);

CREATE TABLE nonHuman
(
	nonHuman_Id		int				primary key			identity(1,1),
	name			varchar(50)		not null,
	playerType		varchar(50)		not null,
	life			int				not null,
	gender			varchar(1)		not null,
	strength		int				not null,
	attack			int				not null,
	defense			int				not null,
	magic			int				not null,
	gold			int				not null,
	level			int				not null,
	CONSTRAINT ck_nonHuman_gender CHECK(gender IN ('M', 'F'))

);

CREATE TABLE entity_inventory
(
	id				int				primary key			identity(1,1),
	inventory_id	int				not null,
	player_id		int				not null,
	store_id		int				not null,
	nonHuman_id		int				not null,
	CONSTRAINT fk_inventory foreign key(inventory_id) references inventory(inventory_id),
	CONSTRAINT fk_player foreign key(player_id)	references player(player_id),
	CONSTRAINT fk_store foreign key(store_id) references store(store_id),
	CONSTRAINT fk_nonHuman foreign key(nonHuman_id) references nonHuman(nonHuman_id),
);

select * from inventory;
delete from inventory;