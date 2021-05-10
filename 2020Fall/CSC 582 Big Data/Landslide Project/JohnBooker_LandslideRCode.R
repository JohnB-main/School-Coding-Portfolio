library(dplyr)
library(ggplot2)

getCountryCount <- function(inputCountry){
  foundCount = subset(CountryCount$countt, CountryCount$country_name == inputCountry)
  return(foundCount)
}



# read csv file
RawGLC = read.csv("Global_Landslide_Catalog_Export.csv", header = TRUE, stringsAsFactors = FALSE) 
# select relevant data to save storage/memory; cut out data without a country name, since it's location cannot be logged besides GPS, which is not this project's focus
trimGLC = RawGLC %>% select(event_id, event_date, country_name, admin_division_name, landslide_category, landslide_trigger, landslide_size) %>% 
  filter((country_name != ""))

# MM/DD/YYYY add column for month and day
trimGLC = trimGLC %>% rowwise () %>% 
  mutate(focusDate = substr(event_date, 1, 5)) # getting only month and day

# count of landslides per country
CountryCount = trimGLC %>% group_by(country_name) %>% 
  summarise(countt = n())

# find percentage of landslides of country compared to total
CountryPercentage = CountryCount %>% rowwise() %>% 
  mutate(toTotal = round(countt/9471*100, 2)) %>% 
  arrange(desc(toTotal))


# count of landslides per country, state(province/region)
StateCount = trimGLC %>% group_by(country_name, admin_division_name) %>% 
  summarise(countt = n())

# find percentage of landslides compared to country; order by country and highest percentage
StatePercentage = StateCount %>% rowwise() %>% 
  mutate(toCountry = round(countt/getCountryCount(country_name)*100, 2)) %>% 
  arrange(desc(countt))

# the max state for each country
TopStatePerCountry = StatePercentage %>% group_by(country_name) %>% 
  filter(countt == max(countt))

# count of landslides per country, state(province/region), date included
  # brazil h ad really bad flooding on one day, which caused many landslides on 04/06
DateStateCount = trimGLC %>% group_by(country_name, admin_division_name, focusDate) %>% 
  summarise(countt = n()) %>% 
  arrange(desc(countt))
# arrange(desc(countt), country_name, admin_division_name, focusDate)

# dataset to hold instances of data for all landslides for a certain state
test = DateStateCount %>% 
  # filter(admin_division_name %in% head(DateStateCount$admin_division_name))
  filter(admin_division_name == "Oregon")


# plotting a point graph with numeric representation for all the days a landslide occcured, for the state in test
ggplot((test), aes(x = admin_division_name, y=focusDate)) + 
  geom_point( alpha = 0.00001 ) + # make the points invisible
  geom_text(aes(label=countt), hjust=0, color="darkBlue", size=3.2) +
  theme(axis.text.x = element_text(angle = 90, vjust = 0.5, hjust=1)) 


# a different representation of one state's frequency; line graph
ggplot((test), aes(x = focusDate, y = countt, group = 1)) + 
  geom_line()+
  geom_point()+
  theme(axis.text.x = element_text(angle = 90, vjust = 0.5, hjust=1))+
  labs(title = "Oregon Frequency",
       x = "Date (MM/DD)",
       y = "Number of Landslides")

# all the entries of landslides from the top 10 states  
trim = DateStateCount %>% 
  filter(admin_division_name %in% head(StatePercentage$admin_division_name, 10))

# visual representation of ALL the top 10 state's timelines
ggplot((trim), aes(x = focusDate, y = countt, color =admin_division_name, group = admin_division_name)) + 
  geom_line()+
  geom_point()+
  theme(axis.text.x = element_text(angle = 90, vjust = 0.5, hjust=1))+
  labs(title = "ALL Frequency",
       x = "Date (MM/DD)",
       y = "Number of Landslides")



# plotting a graph of top 10 countries
ggplot(data=head(CountryPercentage, 10), aes(x=reorder(country_name, -toTotal), y=toTotal)) +
  geom_bar(stat="identity", fill= "darkblue")+
  
  labs(title = "Top Ten Countries with Most Landslides",
       x = "Country",
       y = "Percentage of Landslides")

# state version of top 10
ggplot(data=head(StatePercentage, 10), aes(x=reorder(admin_division_name , -toCountry), y=toCountry)) +
  geom_bar(stat="identity", fill= "darkblue")+
  
  labs(title = "Top Ten States with Most Landslides",
       x = "State",
       y = "Percentage of Landslides")


  


#get count of landslide groups for a country by category
# test = trimGLC %>% group_by(country_name, landslide_category) %>%
#  summarise(countt = n())
