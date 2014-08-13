# Amazon Wishlist Tracker

---
 I'll (probably) no longer continue this block because I (fortunately) found www.camelcamelcamel.com that does this and does it very well!
---

This project is a sort of spike to work on a couple of 
things AND solve a personal itch. 

On one hand, it will allow me to look at some book 
price trends for books on my wishlist; On the other, 
its a chance to test out a couple of tecnologies and 
patterns, namely:

* Queuing with Mass Transit and RabbitMq
* Data storage with MongoDb
* Unit testing with MongoDb abstractions
* Integration Testing with MongoDb
* Testing with message queues
* SpecFlow Acceptance tests
* Canopy UI tests
* Reviewing Web approaches
* CQRS and EventStore Arquitectures, along with DDD aproaches

The problem is simple enough and compact enough to be able 
to apply the ideas presented by the above.

## Functional Motivations

I tend to buy alot of books on Amazon.co.uk (since I'm in Portugal). 
Amazon ships to Portugal with free shipping for orders above £25; Affiliates 
have a fixed price for shipping ( aprox. #4.5 per book). Sometimes the 
diference between prices justifies purchasing though Amazon, sometimes through 
affiliates. I generally don't mind buying used books - must of the times, the
books purchased through affiliates are in excellent condition.

Basically, since my wishlist is kinda long, I end up having a hard time understanding
if any book there should be purchased to save in the long run or, considering 
it isn't urgent, if I should wait a bit.

## Project description

The project currently consists of a scraper that will extract 
the list of books in a set of wishlists, amazon's book price, and
the lowest quote from affiliates, with international shipping. 

> International shipping is something I'm considering as important
> since I'm outside of the UK and not every dealer does international
> shipping

The project will also consist of a web site that will allow me to 
look at the booklist, and price variations through time on the books
in the list. The goals are to:

* Determine if the price of a book has dropped
* Identify if any book is bellow a "buy" threshold
* Determine if the book should be purchased via Amazon or the affiliate, c
onsidering the fixed shipping overhead.

## Arquitectural Motivations

The problem is quite simple and doesn't really need complexity added to it to be solved;
but because it's simple enough, It is a good oportunity to try stuff out. 
Namely, CQRS, event sourcing, document dbs, read model seperation, and queues.

I'm considering a service that periodically (daily?) queries the site to get new books 
and price quotes. After extracting the info, events / comands will be launched to 
update the domain model. Messaging will also be used to update info to the read model.
