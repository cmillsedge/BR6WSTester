# BR6WSTester
BioRails6 Web Service Tester

This is a simple test harness which calls all of the methods in the API. It uses the test database builder data for all data retrieval. 
Any new objects created will be given a date suffix to allow multiple executions. Wherever possible tests are completely independent of any previous test, 
meaning if a test fails then it is not due to a previous test failure.
