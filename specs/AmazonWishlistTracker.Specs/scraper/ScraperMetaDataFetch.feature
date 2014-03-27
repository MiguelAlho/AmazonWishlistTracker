Feature: ScraperMetaDataFetch
	In order to setup the scraping process for my wishlist
	As a screen scraping component
	I want to extract book category data from a wishlist page

@mytag
Scenario: Prepare for book scraping
	Given I have configured my scraper with:
	| base site  | http://www.amazon.co.uk |
	| wishlistId | 2OPMME7SI9MPV           |
	When I retrieve metadata for the scraper
	Then the scraper should know that there are the following wishlists:
	| wishlistName             | wishlistPageId |
	| Business                 | 13WMOM3XTAK5G  |
	| Drawing                  | 2G6OFE9P47AKA  |
	| Electronics              | 1BSEQ7U2E6RBE  |
	| Engeneering and business | 2OPMME7SI9MPV  |
	| Fiction                  | 39ACCHDMKVKJ1  |
	| Home and Stuff           | 32BRN6BOWYVID  |
	| Methodologies            | 20E6BOWWE0J4T  |
	| New Wish List            | 2P8W7HDF4M6NR  |
	| Patterns                 | 34GLJJOVRPDZU  |
	| Photography              | 2WYRZAFDXJ9C2  |
	| PRoductivity             | 1O0W0NU3ZPF1J  |
	| Progamming               | 2CCU7K0PHVBZ6  |
	| Psycology                | 22JADHUMCHCOZ  |
	| Training                 | MT9A2WI1FL61	|
	| Web and UI               | 10MTFE33315HU  |
	| Wish List                | GKBVZ2B8F57P	|
