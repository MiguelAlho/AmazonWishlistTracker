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
	| wishlistName             | wishlistPageId |
	| Business                 | 13WMOM3XTAK5G  |
	| Drawing                  | 2G6OFE9P47AKA  |
	| Electronics              | 1BSEQ7U2E6RBE  |
	| Engeneering and business | 2OPMME7SI9MPV  |
	| Fiction                  | 39ACCHDMKVKJ1  |
	| Home and stuff           | 32BRN6BOWYVID  |
	| Methodologies            | 20E6BOWWE0J4T  |
	| New Wish List            | 2P8W7HDF4M6NR  |
	| Patterns                 | 34GLJJOVRPDZU  |
	| Photography              | 2WYRZAFDXJ9C2  |
	| PRoductivity             | 1O0W0NU3ZPF1J  |
	| programming              | 2CCU7K0PHVBZ6  |
	| Psycology                | 22JADHUMCHCOZ  |
	| Training                 | MT9A2WI1FL61	|
	| Web and UI               | 10MTFE33315HU  |
	| Wish List                | GKBVZ2B8F57P	|
