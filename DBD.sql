CREATE TABLE C##CAR.STAFF_INFORMATION (
    IDENTITY_NUMBER VARCHAR2(50) PRIMARY KEY,
    NAME_ VARCHAR2(50) NOT NULL,
    GENDER CHAR(1) CHECK (GENDER IN ('f', 'm'))
);
CREATE TABLE C##CAR.STAFF (
    EMPLOYEE_ID VARCHAR2(50) PRIMARY KEY,
    USERNAME VARCHAR2(50) NOT NULL,
    PASSWORD_ VARCHAR2(50) NOT NULL,
    AVATAR BLOB,
    CREATION_TIME TIMESTAMP NOT NULL,
    PHONE_NUMBER VARCHAR2(50) DEFAULT '+86',
    ID_CARD_NUMBER VARCHAR2(50) NOT NULL,
    NAME_ VARCHAR2(50) NOT NULL,
    GENDER VARCHAR2(1) CHECK (GENDER IN ('f', 'm')),
    POSITION_ VARCHAR2(50) DEFAULT '-',
    CONSTRAINT FK_STAFF_ID_CARD_NUMBER FOREIGN KEY (ID_CARD_NUMBER)
        REFERENCES C##CAR.STAFF_INFORMATION (ID_CARD_NUMBER)
);

CREATE TABLE C##CAR.SWITCH_STATIONS (
    SWITCH_STATION_ID VARCHAR2(50) PRIMARY KEY,
    STATION_NAME VARCHAR2(50),
    LONGITUDE NUMBER NOT NULL UNIQUE,
    LATITUDE NUMBER NOT NULL UNIQUE,
    AVAILABLE_STATUS VARCHAR2(1) CHECK (AVAILABLE_STATUS IN ('y', 'n')),
    FAULT_STATUS VARCHAR2(1) CHECK (FAULT_STATUS IN ('y', 'n')),
    BATTERY_CAPACITY INT NOT NULL,
    AVAILABLE_BATTERY_COUNT INT DEFAULT 0
);
CREATE TABLE C##CAR.MAINTENANCE_ITEMS (
    MAINTENANCE_ITEM_ID VARCHAR2(50) PRIMARY KEY,
    VEHICLE_ID VARCHAR2(50) NOT NULL,
    MAINTENANCE_LOCATION VARCHAR2(50) UNIQUE,
    REMARKS VARCHAR2(255),
    SERVICE_TIME TIMESTAMP NOT NULL,
    ORDER_SUBMISSION_TIME TIMESTAMP,
    ORDER_STATUS VARCHAR2(1) DEFAULT '0',
    EVALUATION_ VARCHAR2(255),
    CONSTRAINT FK_MAINTENANCE_ITEMS_VEHICLE FOREIGN KEY (VEHICLE_ID)
        REFERENCES C##CAR.VEHICLES (VEHICLE_ID)
);
CREATE TABLE C##CAR.BATTERY (
    BATTERY_ID VARCHAR2(50) PRIMARY KEY,
    AVAILABLE_STATUS VARCHAR2(1) DEFAULT '0',
    TOTAL_CAPACITY INT DEFAULT 100,
    CURRENT_CAPACITY INT NOT NULL,
    BATTERY_LIFE FLOAT NOT NULL,
    MANUFACTURING_DATE TIMESTAMP NOT NULL,
    BATTERY_MODEL VARCHAR2(50) NOT NULL
);
CREATE TABLE C##CAR.ANNOUNCEMENT (
    ANNOUNCEMENT_ID VARCHAR2(50) PRIMARY KEY,
    PUBLISH_TIME TIMESTAMP NOT NULL,
    TITLE VARCHAR2(50) NOT NULL,
    CONTENT_ VARCHAR2(255)
);
CREATE TABLE C##CAR.SWITCH_RECORDS (
    SWITCH_SERVICE_ID VARCHAR2(50) PRIMARY KEY,
    VEHICLE_ID VARCHAR2(50) NOT NULL,
    SWITCH_TIME TIMESTAMP NOT NULL,
    EMPLOYEE_ID VARCHAR2(50) NOT NULL,
    SWAPPED_BATTERY_ID VARCHAR2(50) NOT NULL,
    BATTERY_SOURCE VARCHAR2(50) NOT NULL,
    SWAPPED_OUT_BATTERY_ID VARCHAR2(50) NOT NULL,
    SWAPPED_OUT_BATTERY_DESTINATION VARCHAR2(50) NOT NULL,
    EVALUATION_ VARCHAR2(255)
);
CREATE TABLE C##CAR.PERFORMANCES (
    PERFORMANCE_ID VARCHAR2(50) PRIMARY KEY,
    EMPLOYEE_ID VARCHAR2(50) NOT NULL,
    TOTAL_PERFORMANCE INT NOT NULL,
    SERVICE_COUNT INT DEFAULT 0,
    POSITIVE_RATING INT
);
CREATE TABLE C##CAR.VEHICLES (
    VEHICLE_ID VARCHAR2(50) PRIMARY KEY,
    VEHICLE_MODEL VARCHAR2(50) NOT NULL,
    OWNER_ID VARCHAR2(50) NOT NULL,
    PURCHASE_DATE TIMESTAMP NOT NULL,
    CONSTRAINT FK_VEHICLES_OWNER FOREIGN KEY (OWNER_ID)
        REFERENCES C##CAR.OWNERS (OWNER_ID)
);
CREATE TABLE C##CAR.OWNERS (
    OWNER_ID VARCHAR2(50) PRIMARY KEY,
    OWNER_NICKNAME VARCHAR2(50) NOT NULL,
    PASSWORD_ VARCHAR2(50) NOT NULL,
    AVATAR BLOB DEFAULT 0,
    CREATION_TIME TIMESTAMP NOT NULL,
    PHONE_NUMBER VARCHAR2(50) DEFAULT '+86',
    EMAIL VARCHAR2(50) NOT NULL,
    GENDER CHAR(1) CHECK (GENDER IN ('f', 'm')),
    BIRTHDAY TIMESTAMP,
    ADDRESS VARCHAR2(255)
);
CREATE TABLE C##CAR.SWITCH_REQUESTS (
    SWITCH_REQUEST_ID VARCHAR2(50) PRIMARY KEY,
    VEHICLE_ID VARCHAR2(50) NOT NULL,
    EMPLOYEE_ID VARCHAR2(50) NOT NULL,
    REQUEST_TIME TIMESTAMP NOT NULL,
    REMARKS VARCHAR2(255)
);
CREATE TABLE C##CAR.VEHICLE_PARAMETERS (
    VEHICLE_MODEL VARCHAR2(50) PRIMARY KEY,
    GEAR_TYPE VARCHAR2(50) NOT NULL,
    WARRANTY_PERIOD TIMESTAMP NOT NULL,
    MANUFACTURER VARCHAR2(50) NOT NULL,
    MAX_SPEED NUMBER
);
CREATE TABLE C##CAR.STAFF_IN_SWITCH_STATION (
    EMPLOYEE_ID VARCHAR2(50) PRIMARY KEY,
    SWITCH_STATION_ID VARCHAR2(50) NOT NULL,
    CONSTRAINT FK_STAFF_IN_SWITCH_STATION_EMPLOYEE FOREIGN KEY (EMPLOYEE_ID)
        REFERENCES C##CAR.STAFF (EMPLOYEE_ID),
    CONSTRAINT FK_STAFF_IN_SWITCH_STATION_SWITCH_STATION FOREIGN KEY (SWITCH_STATION_ID)
        REFERENCES C##CAR.SWITCH_STATIONS (SWITCH_STATION_ID)
);
CREATE TABLE C##CAR.COMPLETION_OF_MAINTENANCE (
    MAINTENANCE_ID VARCHAR2(50) PRIMARY KEY,
    EMPLOYEE_ID VARCHAR2(50) NOT NULL,
    CONSTRAINT FK_COMPLETION_OF_MAINTENANCE_EMPLOYEE FOREIGN KEY (EMPLOYEE_ID)
        REFERENCES C##CAR.STAFF (EMPLOYEE_ID)
);
CREATE TABLE C##CAR.ACCEPTANCE_OF_SWITCH_REQUESTS (
    SWITCH_REQUEST_ID VARCHAR2(50) PRIMARY KEY,
    EMPLOYEE_ID VARCHAR2(50) NOT NULL,
    CONSTRAINT FK_ACCEPTANCE_OF_SWITCH_REQUESTS_SWITCH_REQUEST FOREIGN KEY (SWITCH_REQUEST_ID)
        REFERENCES C##CAR.SWITCH_REQUESTS (SWITCH_REQUEST_ID),
    CONSTRAINT FK_ACCEPTANCE_OF_SWITCH_REQUESTS_EMPLOYEE FOREIGN KEY (EMPLOYEE_ID)
        REFERENCES C##CAR.STAFF (EMPLOYEE_ID)
);
CREATE TABLE C##CAR.BATTERY_POSITION (
    BATTERY_ID VARCHAR2(50) PRIMARY KEY,
    POSITION_STATUS INT DEFAULT 0,
    VEHICLE_ID VARCHAR2(50) NOT NULL,
    SWITCH_STATION_ID VARCHAR2(50) NOT NULL,
    CONSTRAINT FK_BATTERY_POSITION_BATTERY FOREIGN KEY (BATTERY_ID)
        REFERENCES C##CAR.BATTERY (BATTERY_ID),
    CONSTRAINT FK_BATTERY_POSITION_VEHICLE FOREIGN KEY (VEHICLE_ID)
        REFERENCES C##CAR.VEHICLES (VEHICLE_ID),
    CONSTRAINT FK_BATTERY_POSITION_SWITCH_STATION FOREIGN KEY (SWITCH_STATION_ID)
        REFERENCES C##CAR.SWITCH_STATIONS (SWITCH_STATION_ID)
);

