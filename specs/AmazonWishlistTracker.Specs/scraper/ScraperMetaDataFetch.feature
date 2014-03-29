Feature: ScraperMetaDataFetch
	In order to setup the scraping processfor my personal wishlist
	As a screen scraping component
	I want to extract the list of wishlists from a wishlist page

@mytag
Scenario: Prepare for book scraping
	Given I have configured my scraper with:
	| AmazonTarget | Email               |
	| UK           | alho@miguelalho.com |
	When I retrieve the users wishlists
	Then the scraper should know that there are the following wishlists:
	| wishlistName             | wishlistPageId | bookCount |
	| Business                 | 13WMOM3XTAK5G  | 47        |
	| Drawing                  | 2G6OFE9P47AKA  | 16        |
	| Electronics              | 1BSEQ7U2E6RBE  | 4         |
	| Engeneering and business | 2OPMME7SI9MPV  | 36        |
	| Fiction                  | 39ACCHDMKVKJ1  | 52        |
	| Home and stuff           | 32BRN6BOWYVID  | 11        |
	| Methodologies            | 20E6BOWWE0J4T  | 35        |
	| New Wish List            | 2P8W7HDF4M6NR  | 0         |
	| Patterns                 | 34GLJJOVRPDZU  | 16        |
	| Photography              | 2WYRZAFDXJ9C2  | 7         |
	| PRoductivity             | 1O0W0NU3ZPF1J  | 0         |
	| programming              | 2CCU7K0PHVBZ6  | 34        |
	| Psycology                | 22JADHUMCHCOZ  | 3         |
	| Training                 | MT9A2WI1FL61   | 3         |
	| Web and UI               | 10MTFE33315HU  | 29        |
	| Wish List                | GKBVZ2B8F57P   | 0         |

Scenario: Get list of books in a specific wishlist
	Given I have configured my scraper with:
	| AmazonTarget | Email               |
	| UK           | alho@miguelalho.com |
	When I retrieve the book list for the Methodologies wishlist
	Then the scraper should find 35 books in the book list
	And the scraper should know that there are the following books are in the wishlist's list
	| bookId     | bookTitle                                                                                           | amazonPrice |
	| 0321534468 | Agile Testing: A Practical Guide for Testers and Agile Teams (Addison-Wesley Signature) (Paperback) | 36.99       |
	| 0932633692 | Perfect Software: And Other Illusions About Testing (Paperback)                                     | 18.99       |
	| 0321554132 | Managing Software Debt: Building for Inevitable Change (Agile Software Development) (Hardcover)     |	         |
	
	