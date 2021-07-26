# import the modules
# # For Config
import config
appConfig = config.Config()

# # For Reddit
import praw

# # For Zeep (SOAP)
from requests import Session
from requests.auth import HTTPBasicAuth

from zeep import Client
from zeep import Transport

# initialize Blue Prism Parameters
wsdl = appConfig.BLUE_PRISM_WSDL
queueName = appConfig.BLUE_PRISM_QUEUE

# create an authorized reddit instance
reddit = praw.Reddit(client_id =  appConfig.REDDIT_CLIENT_ID,
                     client_secret = appConfig.REDDIT_CLIENT_SECRET,
                     username = appConfig.REDDIT_USERNAME,
                     password = appConfig.REDDIT_PW,
                     user_agent = appConfig.REDDIT_USER_AGENT)

# to find the top most submission in the subreddit
subreddit = reddit.subreddit("wallstreetbets")

session = Session()
session.auth = HTTPBasicAuth(appConfig.BLUE_PRISM_USERNAME, appConfig.BLUE_PRISM_PW)

client = Client(wsdl=wsdl, transport=Transport(session=session))

for submission in subreddit.hot(limit = 10):
    # displays the submission title 
    print(submission.title)   
    # displays the net upvotes of the submission 
    print(submission.score)   
    # displays the submission's ID 
    print(submission.id)    
    # displays the url of the submission 
    print(submission.url)  
    client.service.InsertintoQueue(queueName, submission.id, submission.title, submission.score, submission.url, '')
