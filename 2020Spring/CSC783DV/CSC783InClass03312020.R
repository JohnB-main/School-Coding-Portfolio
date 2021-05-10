#John Booker
#In Class Lecture submit due 3/31/2020
#lecture 12

#install.packages("ggiraphExtra")
#install.packages("ggplot2")
#install.packages("plotly")
#install.packages("dygraphs")
library(ggiraphExtra)

str(USArrests)

head(USArrests)

library(tibble)

crime <- rownames_to_column(USArrests, var ="state")
crime$state <- tolower(crime$state)

str(crime)

library(ggplot2)
states_map <- map_data("state")
str(states_map)

library(maps)
library(mapproj)
ggChoropleth(data= crime,
            aes(fill= Murder,
                map_id=state),
            map = states_map,
            interactive = T)




library(plotly)

p <- ggplot(data=mpg, aes(x=displ, y=hwy, col= drv)) + geom_point()
     
ggplotly(p)

p <- ggplot(data = diamonds, aes(x=cut, fill=clarity))+
  geom_bar(position = "dodge")

ggplotly(p)
show(p)


library(dygraphs)

economics <- ggplot2::economics
head(economics)

library(xts)

eco <- xts(economics$unemploy, order.by = economics$date)
head(eco)

dygraph(eco) %>% dyRangeSelector()


eco_a <- xts(economics$psavert, order.by = economics$date)
eco_b <-xts(economics$unemploy/1000, order.by = economics$date)

eco2 <- cbind(eco_a, eco_b)
colnames(eco2) <- c("psavert", "unemploy")
head(eco2)

dygraph(eco2) %>%  dyRangeSelector()
