## Reddit Bot ##

# Introduction #

Build a Reddit Bot that will monitor certain subreddits and then pass those post to Blue Prism to work and send to get sentiment analysis. 

# Guides #

https://levelup.gitconnected.com/creating-a-reddit-bot-using-python-5464d4a5dff2

https://chatbots.studio/blog/how-to-make-a-reddit-bot-with-python/ (optional)

https://code.visualstudio.com/docs/python/python-tutorial


# Setup #
**Reddit**

- Create or use existing Reddit User Acct. 
- Go to this URL https://www.reddit.com/prefs/apps/ and select Create App.
	
**Python**

We’ll use the PRAW python library to make working with Reddit’s API easier. We’re also using ZEEP to interface with Blue Prism’s SOAP APIs.  Install Python, PIP, PRAW, and ZEEP.

- Install Python - https://www.python.org/downloads/release/python-391/

- In the “setup” folder there is already a copy of get-pip.py which you can use to install PIP.
- Install PIP - https://pip.pypa.io/en/stable/installing/
- Install PRAW - https://praw.readthedocs.io/en/latest/getting_started/installation.html

- For SOAP install ZEEP - https://docs.python-zeep.org/en/master/

**Blue Prism** 

- Import the Blue Prism release “20210210 Insert into BP Queue.bprelease” into Blue Prism. This will import the Blue Prism process and the Blue Prism Reddit queue.

- Expose the Blue Prism process.

- We’ll use the Blue Prism wsdl to help build the python script connection.

# Help #

- Python: https://hackernoon.com/4-ways-to-manage-the-configuration-in-python-4623049e841b
	
- HTTP Authentication for ZEEP: https://docs.python-zeep.org/en/master/transport.html

 
