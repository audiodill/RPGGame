--DROP TABLE nonHuman_item;
--DROP TABLE player_attribute;
--DROP TABLE nonHuman_attribute;
--DROP TABLE item_attribute;
--DROP TABLE player_equipmentSlot;
--DROP TABLE equipmentSlot
--DROP TABLE player;
--DROP TABLE store;
--DROP TABLE item_type;
--DROP TABLE item;
--DROP TABLE nonHuman;
--DROP TABLE attribute;

CREATE TABLE player
(
	player_id			int				primary key			identity(1,1),
	name				varchar(50)		not null,
	life				int				not null,
	gender				varchar(1)		not null,
	xp					int				not null,
	strength			int				not null,
	attack				int				not null,
	defense				int				not null,
	magic				int				not null,
	xpLevel				int				not null,
	gold				int				not null,
	playertype			varchar(50)		not null,
	CONSTRAINT ck_gender CHECK(gender IN ('M','F'))
);

CREATE TABLE attribute
(
	attribute_id		int				primary key			identity(1,1),
	name				varchar(50)		not null,
	descript			varchar(255)	not null,
);

CREATE TABLE item_type
(
	item_type_id		int				primary key			identity(1,1),
	name				varchar(50)		not null,
	descript			varchar(255)	not null,
		
);

CREATE TABLE item
(
	item_id				int				primary key			identity(1,1),
	item_type_id		int				not null,
	name				varchar(50)		not null,
	type				varchar(50)		not null,
	weight				decimal			not null,
	requiredLevel		int				not null,
	durability			int				not null,
	CONSTRAINT uq_item unique (name),
	CONSTRAINT uq_item_type_item foreign key(item_type_id) references item_type(item_type_id)
);

CREATE TABLE equipmentSlot
(
	equipmentSlot_id	int				primary key			identity(1,1),
	name				varchar(50)		not null,
	CONSTRAINT uq_name unique (name),
);

CREATE TABLE player_equipmentSlot
(
	player_equipmentSlot_id	int			primary key			identity(1,1),
	player_id			int				not null,
	equipmentSlot_id	int				not null,
	item_id				int				not null,
	CONSTRAINT uq_equipmentSlot_id_player_id unique (equipmentSlot_id, player_id),
	CONSTRAINT fk_player_equipmentSlot_equipmentSlot foreign key (equipmentSlot_id) references equipmentSlot(equipmentSlot_id),
	CONSTRAINT fk_player_equipmentSlot_player foreign key (player_id) references player(player_id),
	CONSTRAINT fk_player_equipmentSlot_item foreign key (item_id) references item(item_id),
);

CREATE TABLE item_attribute
(
	item_attribute_id	int				primary key			identity(1,1),
	item_id				int				not null,
	attribute_id		int				not null,
	value				int				not null,
	CONSTRAINT uq_item_id_attribute_id unique (item_id, attribute_id),
	CONSTRAINT fk_item_item_attribute foreign key (item_id) references item(item_id),
	CONSTRAINT fk_attribute_item_attribute foreign key (attribute_id) references attribute(attribute_id),
);

CREATE TABLE store
(
	store_id			int				primary key			identity(1,1),
	name				varchar(50)		not null,
	location			varchar(50)		not null,
	type				varchar(50)		not null,
	gold				int				not null,
	storeLevel			int				not null,
	CONSTRAINT uq_name_location unique(name, location)
);

CREATE TABLE nonHuman
(
	nonHuman_Id			int				primary key			identity(1,1),
	name				varchar(50)		not null,
	playerType			varchar(50)		not null,
	life				int				not null,
	gender				varchar(1)		not null,
	gold				int				not null,
	level				int				not null,
	CONSTRAINT ck_nonHuman_gender CHECK(gender IN ('M', 'F'))

);

CREATE TABLE nonHuman_item
(
	id					int				primary key			identity(1,1),
	item_id				int				not null,
	store_id			int				not null,
	nonHuman_id			int				not null,
	CONSTRAINT fk_item foreign key(item_id) references item(item_id),
	CONSTRAINT fk_store foreign key(store_id) references store(store_id),
	CONSTRAINT fk_nonHuman foreign key(nonHuman_id) references nonHuman(nonHuman_id)
);

CREATE TABLE nonHuman_attribute
(
	nonHuman_attribute	int				primary key			identity(1,1),
	nonHuman_id			int				not null,
	attribute_id		int				not null,
	value				int				not null,
	CONSTRAINT uq_nonHuman_id_attribute_id unique (nonHuman_id, attribute_id),
	CONSTRAINT fk_nonHuman_nonHuman_attribute foreign key (nonHuman_id) references nonHuman(nonHuman_id),
	CONSTRAINT fk_attribute_nonHuman_attribute foreign key (attribute_id) references attribute(attribute_id)
);

CREATE TABLE player_attribute
(
	player_attribute_id	int				primary key			identity(1,1),
	player_id			int				not null,
	attribute_id		int				not null,
	value				int				not null,
	CONSTRAINT uq_player_id_attribute_id unique(player_id, attribute_id),
	CONSTRAINT fk_player_player_attribute foreign key (player_id) references player(player_id),
	CONSTRAINT fk_attribute_player_attribute foreign key (attribute_id) references attribute(attribute_id)
);

