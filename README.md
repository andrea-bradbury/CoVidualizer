# CoVidualizer
A simple 4 page app to view current stats about COVID around the world.

The app uses the About Corona API https://about-corona.net/ to source top line data on COVID-19 around the world. 

Upon open the app collect the current data from https://about-corona.net/ via the API, 
stores the data as COVIDCountry Objects as uses these attributes to manipluate and display data. 

The app has 4 screens:
- Homepage (world covid data)
- Your location (which is set using preferences)
- Hot Spots and Low Spots (as determined by the highest cases_per_million_population data)
- Preference (for setting your location)
