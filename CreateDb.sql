CREATE TABLE `ActorChildren` (
  `ParentActorId` int(11) NOT NULL DEFAULT '0',
  `ChildActorId` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ParentActorId`,`ChildActorId`),
  KEY `Parent_idx` (`ChildActorId`),
  CONSTRAINT `ChildFk` FOREIGN KEY (`ChildActorId`) REFERENCES `Actors` (`ActorId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `ParentFk` FOREIGN KEY (`ParentActorId`) REFERENCES `Actors` (`ActorId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `ActorIssueOpinion` (
  `ActorId` int(11) NOT NULL,
  `IssueId` int(11) NOT NULL,
  `OpinionId` int(11) DEFAULT NULL,
  `DateModified` datetime NOT NULL,
  `Notes` longtext,
  PRIMARY KEY (`ActorId`,`IssueId`),
  KEY `Issues_idx` (`IssueId`),
  KEY `Opinion_idx` (`OpinionId`),
  CONSTRAINT `ActorsFk` FOREIGN KEY (`ActorId`) REFERENCES `Actors` (`ActorId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `IssuesFk` FOREIGN KEY (`IssueId`) REFERENCES `Issues` (`IssueId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `OpinionFk` FOREIGN KEY (`OpinionId`) REFERENCES `Opinions` (`OpinionId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `Actors` (
  `ActorId` int(11) NOT NULL AUTO_INCREMENT,
  `DateCreated` datetime NOT NULL,
  `DateModified` datetime NOT NULL,
  `Name` varchar(255) NOT NULL,
  `ActorTypeId` int(11) DEFAULT NULL,
  `Active` bit(1) DEFAULT NULL,
  `GlobalInfluence` int(11) DEFAULT NULL,
  PRIMARY KEY (`ActorId`),
  KEY `ActorTypes_idx` (`ActorTypeId`),
  CONSTRAINT `ActorTypesFk` FOREIGN KEY (`ActorTypeId`) REFERENCES `ActorTypes` (`ActorTypeId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

CREATE TABLE `ActorTypes` (
  `ActorTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `DateCreated` datetime NOT NULL,
  `Name` varchar(255) NOT NULL,
  PRIMARY KEY (`ActorTypeId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

CREATE TABLE `AskActor` (
  `AskId` int(11) NOT NULL,
  `ActorId` int(11) NOT NULL,
  `OpinionId` int(11) NOT NULL,
  `Notes` longtext COLLATE utf8_sinhala_ci,
  `DateModified` datetime NOT NULL,
  PRIMARY KEY (`AskId`,`ActorId`),
  KEY `OpinionsFk_idx` (`OpinionId`),
  KEY `ActorFk_idx` (`ActorId`),
  CONSTRAINT `ActorFk` FOREIGN KEY (`ActorId`) REFERENCES `Actors` (`ActorId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `AskFk` FOREIGN KEY (`AskId`) REFERENCES `Asks` (`AskId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `OpinionsFk` FOREIGN KEY (`OpinionId`) REFERENCES `Opinions` (`OpinionId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_sinhala_ci;

CREATE TABLE `AskObjectives` (
  `AskId` int(11) NOT NULL,
  `ObjectiveId` int(11) NOT NULL,
  PRIMARY KEY (`AskId`,`ObjectiveId`),
  KEY `ObjectiveFk_idx` (`ObjectiveId`),
  CONSTRAINT `AsksFk` FOREIGN KEY (`AskId`) REFERENCES `Asks` (`AskId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `ObjectiveFk` FOREIGN KEY (`ObjectiveId`) REFERENCES `Objectives` (`ObjectiveId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `Asks` (
  `AskId` int(11) NOT NULL AUTO_INCREMENT,
  `DateCreated` datetime NOT NULL,
  `DateModified` datetime NOT NULL,
  `TargetDate` datetime DEFAULT NULL,
  `OwnerId` int(11) DEFAULT NULL,
  `AskStatusId` int(11) DEFAULT NULL,
  `Name` varchar(5000) NOT NULL,
  `Notes` longtext,
  PRIMARY KEY (`AskId`),
  KEY `OwnerFk_idx` (`OwnerId`),
  KEY `AskStatusFk_idx` (`AskStatusId`),
  CONSTRAINT `AskStatusFk` FOREIGN KEY (`AskStatusId`) REFERENCES `AskStatuses` (`AskStatusId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `OwnerFk` FOREIGN KEY (`OwnerId`) REFERENCES `Staff` (`StaffId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

CREATE TABLE `AskStatuses` (
  `AskStatusId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`AskStatusId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

CREATE TABLE `AttendanceStatus` (
  `AttendanceStatusId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`AttendanceStatusId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `Departments` (
  `DepartmentId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`DepartmentId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

CREATE TABLE `EventActorAsks` (
  `EventActorId` int(11) NOT NULL DEFAULT '0',
  `AskId` int(11) NOT NULL DEFAULT '0',
  `DateCreated` datetime NOT NULL,
  `DateModified` datetime NOT NULL,
  PRIMARY KEY (`EventActorId`),
  KEY `AskFkWtf_idx` (`AskId`),
  CONSTRAINT `AskFkWtf` FOREIGN KEY (`AskId`) REFERENCES `Asks` (`AskId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `EventActorFk` FOREIGN KEY (`EventActorId`) REFERENCES `EventActors` (`EventActorId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `EventActors` (
  `EventActorId` int(11) NOT NULL,
  `EventId` int(11) DEFAULT '0',
  `ActorId` int(11) DEFAULT '0',
  `AttendingStatusId` int(11) NOT NULL,
  `DateModified` datetime NOT NULL,
  PRIMARY KEY (`EventActorId`),
  UNIQUE KEY `ActorEvent_UNIQUE` (`EventId`,`ActorId`),
  KEY `TheActorFk_idx` (`ActorId`),
  KEY `AttendingStatusFk_idx` (`AttendingStatusId`),
  CONSTRAINT `AttendingStatusFk` FOREIGN KEY (`AttendingStatusId`) REFERENCES `AttendanceStatus` (`AttendanceStatusId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `TheActorFk` FOREIGN KEY (`ActorId`) REFERENCES `Actors` (`ActorId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `TheEventFk` FOREIGN KEY (`EventId`) REFERENCES `Events` (`EventId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `Events` (
  `EventId` int(11) NOT NULL AUTO_INCREMENT,
  `OpportunityId` int(11) NOT NULL,
  `DateCreated` datetime NOT NULL,
  `DateModified` datetime NOT NULL,
  `StartDate` datetime NOT NULL,
  `EndDate` datetime DEFAULT NULL,
  `Name` varchar(5000) NOT NULL,
  `OwnerId` int(11) DEFAULT NULL,
  `Priority` int(11) DEFAULT NULL,
  `EventStatusId` int(11) NOT NULL,
  `Notes` longtext,
  PRIMARY KEY (`EventId`),
  KEY `TheOpportunityFk_idx` (`OpportunityId`),
  KEY `EventStatusFk_idx` (`EventStatusId`),
  KEY `TheOwnerFkWtf_idx` (`OwnerId`),
  CONSTRAINT `EventStatusFk` FOREIGN KEY (`EventStatusId`) REFERENCES `EventStatus` (`EventStatusId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `TheOpportunityFk` FOREIGN KEY (`OpportunityId`) REFERENCES `Opportunities` (`OpportunityId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `TheOwnerFkWtf` FOREIGN KEY (`OwnerId`) REFERENCES `Staff` (`StaffId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `EventStatus` (
  `EventStatusId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`EventStatusId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

CREATE TABLE `Issues` (
  `IssueId` int(11) NOT NULL AUTO_INCREMENT,
  `DateCreated` datetime NOT NULL,
  `DateModified` datetime NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Active` bit(1) DEFAULT b'0',
  `InPurview` bit(1) NOT NULL,
  `OwnerId` int(11) DEFAULT NULL,
  `Notes` longtext,
  PRIMARY KEY (`IssueId`),
  KEY `TheOwnerFk_idx` (`OwnerId`),
  CONSTRAINT `TheOwnerFk` FOREIGN KEY (`OwnerId`) REFERENCES `Staff` (`StaffId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

CREATE TABLE `Objectives` (
  `ObjectiveId` int(11) NOT NULL AUTO_INCREMENT,
  `IssueId` int(11) NOT NULL,
  `DateCreated` datetime NOT NULL,
  `DateModified` datetime NOT NULL,
  `TargetDate` datetime DEFAULT NULL,
  `Name` varchar(255) NOT NULL,
  `ObjectiveStatusId` int(11) NOT NULL,
  `OwnerId` int(11) DEFAULT NULL,
  `Notes` longtext,
  PRIMARY KEY (`ObjectiveId`),
  KEY `Issues_idx` (`IssueId`),
  KEY `ObjectiveStatusFk_idx` (`ObjectiveStatusId`),
  KEY `TheStaffFk_idx` (`OwnerId`),
  CONSTRAINT `Issues` FOREIGN KEY (`IssueId`) REFERENCES `Issues` (`IssueId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `ObjectiveStatusFk` FOREIGN KEY (`ObjectiveStatusId`) REFERENCES `ObjectiveStatuses` (`ObjectiveStatusId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `TheStaffFk` FOREIGN KEY (`OwnerId`) REFERENCES `Staff` (`StaffId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

CREATE TABLE `ObjectiveStatuses` (
  `ObjectiveStatusId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`ObjectiveStatusId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

CREATE TABLE `Opinions` (
  `OpinionId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Value` int(11) NOT NULL,
  PRIMARY KEY (`OpinionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `Opportunities` (
  `OpportunityId` int(11) NOT NULL AUTO_INCREMENT,
  `DateCreated` datetime NOT NULL,
  `DateModified` datetime NOT NULL,
  `StartDate` datetime NOT NULL,
  `EndDate` datetime DEFAULT NULL,
  `Name` varchar(500) NOT NULL,
  `OwnerId` int(11) DEFAULT NULL,
  `Importance` int(11) DEFAULT NULL,
  `EventStatusId` int(11) NOT NULL,
  `Notes` longtext,
  PRIMARY KEY (`OpportunityId`),
  KEY `EventStatusFkWtf_idx` (`EventStatusId`),
  KEY `OwnerFk_idx` (`OwnerId`),
  CONSTRAINT `EventStatusFkWtf` FOREIGN KEY (`EventStatusId`) REFERENCES `EventStatus` (`EventStatusId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `StaffFkwtf` FOREIGN KEY (`OwnerId`) REFERENCES `Staff` (`StaffId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

CREATE TABLE `OpportunityActors` (
  `OpportunityId` int(11) NOT NULL DEFAULT '0',
  `ActorId` int(11) NOT NULL DEFAULT '0',
  `AttendanceStatusId` int(11) NOT NULL,
  `DateModified` datetime NOT NULL,
  PRIMARY KEY (`OpportunityId`,`ActorId`),
  KEY `TheActorFkWtf_idx` (`ActorId`),
  KEY `AttendanceStatusFk_idx` (`AttendanceStatusId`),
  CONSTRAINT `AttendanceStatusFk` FOREIGN KEY (`AttendanceStatusId`) REFERENCES `AttendanceStatus` (`AttendanceStatusId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `TheActorFkWtf` FOREIGN KEY (`ActorId`) REFERENCES `Actors` (`ActorId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `TheOpportunityFkWtf` FOREIGN KEY (`OpportunityId`) REFERENCES `Opportunities` (`OpportunityId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `Staff` (
  `StaffId` int(11) NOT NULL AUTO_INCREMENT,
  `DepartmentId` int(11) DEFAULT NULL,
  `FirstName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `Email` varchar(500) NOT NULL,
  `Phone1` varchar(45) DEFAULT NULL,
  `Phone2` varchar(45) DEFAULT NULL,
  `DateCreated` datetime NOT NULL,
  `DateModified` datetime NOT NULL,
  PRIMARY KEY (`StaffId`),
  KEY `DepartmentFk_idx` (`DepartmentId`),
  CONSTRAINT `DepartmentFk` FOREIGN KEY (`DepartmentId`) REFERENCES `Departments` (`DepartmentId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
