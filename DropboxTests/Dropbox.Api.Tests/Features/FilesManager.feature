Feature: FilesManager

@Get
Scenario: Get all files
	When I try to get list of all existing files
	Then I should get valid list of files

@Upload
Scenario Outline: Upload a file
	Given I have 'MyPdf.pdf' file to upload
	When I upload the file
		| Path   | Mode | AutoRename | Mute  |
		| <path> | add  | true       | false |
	Then I should be able to get file info
		| Name   |
		| <name> |
Examples:
		| path             | name       |
		| /MyFile.pdf      | MyFile.pdf |
		| /Test/MyFile.pdf | MyFile.pdf |

@mytag
Scenario: Create a folder
	When I create '/KatesFolder' folder
	Then The folder exists

Scenario: Delete folder
	Given '/Test' folder is created
	When I delete '/Test' folder
	Then I should be able to get info about deleted folder
		| Name |
		| Test |

Scenario: Delete file
	Given I have 'MyPdf.pdf' file to upload
	When I upload the file
		| Path        | Mode | AutoRename | Mute  |
		| /MyFile.pdf | add  | true       | false |
	When I delete '/MyFile.pdf' file
	Then I should be able to get info about deleted file
		| Name       |
		| MyFile.pdf |
 



