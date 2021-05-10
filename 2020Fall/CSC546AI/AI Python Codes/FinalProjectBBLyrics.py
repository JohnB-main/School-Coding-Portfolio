import warnings

warnings.simplefilter(action='ignore', category=FutureWarning)
import tensorflow as tf
import matplotlib.pyplot as plt
import numpy as np
import random
import pprint as pp
from sklearn.preprocessing import MinMaxScaler

# lyrics from https://www.azlyrics.com/lyrics/breakingbenjamin/

import os

os.environ['KMP_DUPLICATE_LIB_OK'] = 'True'
tf.set_random_seed(777)

'lyrics extraction'
# song = "Will the faithful be rewarded When we come to the end Will I miss the final warning From the lie that I have lived Is there anybody calling I can see the soul within And I am not worthy I am not worthy of this Are you with me after all Why can't I hear you Are you with me through it all Then why can't I feel you Stay with me, don't let me go Because there's nothing left at all Stay with me, don't let me go Until the Ashes of Eden fall Will the darkness fall upon me When the air is growing thin Will the light begin to pull me To its everlasting will I can hear the voices haunting There is nothing left to fear And I am still calling I am still calling to you Are you with me after all Why can't I hear you Are you with me through it all Then why can't I feel you Stay with me, don't let me go Because there's nothing left at all Stay with me, don't let me go Until the Ashes of Eden fall Don't let go Why can't I hear you Stay with me, don't let me go Because there's nothing left at all Stay with me, don't let me go Until the Ashes of Eden fall Heaven above me, take my hand (Stay with me, don't let me go) Shine until there's nothing left but you Heaven above me, take my hand (Stay with me, don't let me go) Shine until there's nothing left but you"
# test = song.replace(',', "")
# test = test.replace('!', "")
# test = test.replace('(', "")
# test = test.replace(')', "")
# test = test.replace(';', "")
# test = test.replace('.', "")
# test = test.replace("'", "")
# test = test.lower()
# print(song)
# print(test)

song = "life will come our way it has only just begun the world will die alone the frail will fall below time will take our place we return it back to one the calm before the cold the long and lonely road look for the light that leads me home tired of feeling lost tired of letting go tear the whole world down tear the whole world down failure drive the cloud away we will fall from last to none the dark before the dawn the world will carry on look for the light that leads me home tired of feeling lost tired of letting go tear the whole world down tear the whole world down tired of wasted breath tired of nothing left tear the whole world down tear the whole world down failure tired of feeling lost tired of letting go tear the whole world down tear the whole world down tired of wasted breath tired of nothing left tear the whole world down tear the whole world down we bury the sunlight we bury the sunlight failure failure we bury the sunlight we bury the sunlight failure failure failure i try to face the fight within but its over im ready for the riot to begin and surrender i walked the path that led me to the end remember im caught beneath with nothing left to give forever when angels fall with broken wings i cant give up i cant give in when all is lost and daylight ends ill carry you and we will live forever forever grey skies will chase the light away no longer i fought the fight now only dark remains forever divided i will stand and i will let this end when angels fall with broken wings i cant give up i cant give in when all is lost and daylight ends ill carry you and we will live forever forever the sun begins to rise and wash away the sky the turning of the tide dont leave it all behind and i will never say goodbye when angels fall with broken wings i cant give up i cant give in when all is lost and daylight ends ill carry you and we will live forever forever forever forever ill keep my sights on awaking dream i gave my life to the vile beneath i am but one of a dying breed hate kills this world but it wont kill me wake up the victim of violence shut the breath of the lifeless im breaking the silence im falling apart for you wake up the victim of violence shut the breath of the lifeless im chasing the righteous becoming a part of you fake plastic life full of wasted years love lost inside diabolic fear i feel no fault for the fault i feel hope drains this world but it wont drain me wake up the victim of violence shut the breath of the lifeless im breaking the silence im falling apart for you wake up the victim of violence shut the breath of the lifeless im chasing the righteous becoming a part of you run wake up the victim of violence shut the breath of the lifeless im breaking the silence im falling apart for you wake up the victim of violence shut the breath of the lifeless im chasing the righteous becoming a part of you im breaking the silence im falling down with you stay alive heaven holds a place for us tonight i am paralyzed close your eyes drive away the cloud that hides the light and leave the pain behind dead alive find a way to bury all the lies escape the pain inside ‘cause i dont want to fall or let you go love left me hollow im with you in the end cold crippled and shallow dont leave me here again fruit of life i can hear the voices of the hive chemicals collide loaded smile light the way for those you left behind set the earth on fire ‘cause i dont want enough i want it all love left me hollow im with you in the end cold crippled and shallow dont leave me here again i cant go on you are bound to break me in i come undone as you drag me down again i come undone love left me hollow im with you in the end cold crippled and shallow dont leave me here again i cant go on you are bound to break me in i come undone as you drag me down again pain come alive i try to breathe shade my eyes follow the damned i have lost the way again stay trust in life carried beneath dead arise sorrow avenged i will face the weak within so ill stay unforgiven and ill keep love together and ill be yours forever ill sleep close to heaven hate lost inside i dare to dream faithless lies caught in the web i will face the weak within so ill stay unforgiven and ill keep love together and ill be yours forever ill sleep close to heaven im coming home im coming home im coming home release me my love so ill stay unforgiven and ill keep love together and ill be yours forever ill sleep close to heaven ill sleep close to heaven ill sleep close to heaven i keep falling out of line i was drained and left behind all will fade and petrify feed the hate and starve the lies falling in between i am caught beneath light the way and let me go suffocate inside i will break and watch you crawl bury me alive i keep falling out of time i was blamed and cauterized all will change and calcify feed the hate and starve the lies falling in between i am caught beneath light the way and let me go suffocate inside i will break and watch you crawl bury me alive control lies inside lies inside light the way and let me go suffocate inside i will break and watch you crawl bury me alive light the way and let me go suffocate inside i will break and watch you crawl bury me alive bury me alive bury me alive carry me under leave me abandoned show me whats left show me whats left beautiful anger breaking the pattern show me whats left show me whats left take the color from your eyes i bleed for you i bleed for you bring the broken back to life well make it through well make it through empty and perfect shattered and worthless show me whats left show me whats left dragging me further forget to remember show me whats left show me whats left take the color from your eyes i bleed for you i bleed for you bring the broken back to life well make it through well make it through never again never again time will not take the life from me never again never again time will not take the life from me and after this world is out of reach sober and silent faded and violent hopeless i fight to fall between never surrender out of the embers save a space inside for me take the color from your eyes i bleed for you i bleed for you bring the broken back to life well make it through well make it through never again never again time will not take the life from me never again never again time will not take the life from me carry me all through the night i am the last light fading leave all the lost souls behind show me the silence breaking and when youre lost and out of time i will be right here waiting and when your dreams return to life ill be forever fading and well fall behind so ill wait for you as i keep your faith alive and ill pray for you as we cross the great divide bury the wounds deep inside rupture the fault line breaking dream of the world left behind show us were worth forsaking and when the cold begins to rise darkness is overtaking and when the fear is satisfied ill be forever changing as we all arise so ill wait for you as i keep your faith alive and ill pray for you as we cross the great divide and ill break for you as i open up the sky and ill stay for you as we cross the great divide follow the sunlight down cry clear and loud heaven wont help us now but its better this way warm light wash me away so ill wait for you as i keep your faith alive and ill pray for you as we cross the great divide and ill break for you as i open up the sky and ill stay for you as we cross the great divide will the faithful be rewarded when we come to the end will i miss the final warning from the lie that i have lived is there anybody calling i can see the soul within and i am not worthy i am not worthy of this are you with me after all why cant i hear you are you with me through it all then why cant i feel you stay with me dont let me go because theres nothing left at all stay with me dont let me go until the ashes of eden fall will the darkness fall upon me when the air is growing thin will the light begin to pull me to its everlasting will i can hear the voices haunting there is nothing left to fear and i am still calling i am still calling to you are you with me after all why cant i hear you are you with me through it all then why cant i feel you stay with me dont let me go because theres nothing left at all stay with me dont let me go until the ashes of eden fall dont let go why cant i hear you stay with me dont let me go because theres nothing left at all stay with me dont let me go until the ashes of eden fall heaven above me take my hand stay with me dont let me go shine until theres nothing left but you heaven above me take my hand stay with me dont let me go shine until theres nothing left but you"

# song = "will the faithful be rewarded when we come to the end will i miss the final warning from the lie that i have lived is there anybody calling i can see the soul within and i am not worthy i am not worthy of this are you with me after all why cant i hear you are you with me through it all then why cant i feel you stay with me dont let me go because theres nothing left at all stay with me dont let me go until the ashes of eden fall will the darkness fall upon me when the air is growing thin will the light begin to pull me to its everlasting will i can hear the voices haunting there is nothing left to fear and i am still calling i am still calling to you are you with me after all why cant i hear you are you with me through it all then why cant i feel you stay with me dont let me go because theres nothing left at all stay with me dont let me go until the ashes of eden fall dont let go why cant i hear you stay with me dont let me go because theres nothing left at all stay with me dont let me go until the ashes of eden fall heaven above me take my hand stay with me dont let me go shine until theres nothing left but you heaven above me take my hand stay with me dont let me go shine until theres nothing left but you"
# song = "this is the song it is a song"
words = (set(song.split(' ')))
# print(len(words)) # 80


word_set = list(set(song.split(' '))) #345 unique words
word_dic = {w: i for i, w in enumerate(word_set)}

# parameters
data_dim = len(word_set)
hidden_size = len(word_set)
num_classes = len(word_set)
sequence_length = 1
learning_rate = 0.1

dataX = []
dataY = []
for i in range(0, len(song.split(' ')) - sequence_length):
    x_str = song.split(' ')[i: i + sequence_length]
    y_str = song.split(' ')[i + 1: i + sequence_length + 1]
    print(i, x_str, '->', y_str)
    x = [word_dic[c] for c in x_str]  # x str to index
    y = [word_dic[c] for c in x_str]  # y str to index
    dataX.append(x)
    dataY.append(y)

# print(dataX)
# print(dataY)

batch_size = len(dataX)

X = tf.placeholder(tf.int32, [None, sequence_length])
Y = tf.placeholder(tf.int32, [None, sequence_length])

x_one_hot = tf.one_hot(X, num_classes)
# print(x_one_hot)

cell = tf.contrib.rnn.BasicLSTMCell(num_units=hidden_size, state_is_tuple=True)
cell = tf.contrib.rnn.MultiRNNCell([cell] * 2, state_is_tuple=True)

initial_state = cell.zero_state(batch_size, tf.float32)

outputs, _states = tf.nn.dynamic_rnn(cell, x_one_hot, initial_state=initial_state, dtype=tf.float32)

x_for_fc = tf.reshape(outputs, [-1, hidden_size])
outputs = tf.contrib.layers.fully_connected(x_for_fc, num_classes, activation_fn=None)

outputs = tf.reshape(outputs, [batch_size, sequence_length, num_classes])
# All weights are 1 (equal weights )
weights = tf.ones([batch_size, sequence_length])

sequence_loss = tf.contrib.seq2seq.sequence_loss(logits=outputs, targets=Y, weights=weights)

mean_loss = tf.reduce_mean(sequence_loss)
train_op = tf.train.AdamOptimizer(learning_rate=0.1).minimize(mean_loss)

sess = tf.Session()
sess.run(tf.global_variables_initializer())
for i in range(100):
    _, l, results = sess.run([train_op, mean_loss, outputs], feed_dict={X: dataX, Y: dataY})
    for j, result in enumerate(results):
        index = np.argmax(result, axis=1)
        tmp_x = ' '.join([word_set[t] for t in dataX[j]])
        tmp_p = ' '.join([word_set[t] for t in index])
        tmp_y = ' '.join([word_set[t] for t in dataY[j]])
        cmt = '[{}] Input=[{}], \tLabel=[{}], \tPrediction=[{}], \t Loss={}'.format(i, tmp_x, tmp_y, tmp_p, l)
        # if (i % 25 == 0):
            # print(cmt)

    # print the last word of each result to check it works
    cmt = '\n\n [[ Trained Sentences ]]'
    print(cmt)
    results = sess.run(outputs, feed_dict={X: dataX})
    for j, result in enumerate(results):
        index = np.argmax(result, axis=1)
        if j is 0:  # print all for the first result to make a song
            tmp = ' '.join([word_set[t] for t in index])
            cmt = '** The first batch j={} is [{}] **\n'.format(j, tmp)
            print(cmt)
            print(' '.join([word_set[t] for t in index]), end=' ')
        else:
            print(word_set[index[-1]], end=' ')

    cmt = '----------------------------------------------------------'
    print(cmt)



'using keras'
# from keras.models import Sequential
# from keras.layers import Dense
# from keras.layers import Dropout
# from keras.layers import LSTM
# from keras.callbacks import ModelCheckpoint
# from keras.utils import np_utils
#
# # load ascii text and covert to lowercase
#
#
# song = "will the faithful be rewarded when we come to the end will i miss the final warning from the lie that i have lived is there anybody calling i can see the soul within and i am not worthy i am not worthy of this are you with me after all why cant i hear you are you with me through it all then why cant i feel you stay with me dont let me go because theres nothing left at all stay with me dont let me go until the ashes of eden fall will the darkness fall upon me when the air is growing thin will the light begin to pull me to its everlasting will i can hear the voices haunting there is nothing left to fear and i am still calling i am still calling to you are you with me after all why cant i hear you are you with me through it all then why cant i feel you stay with me dont let me go because theres nothing left at all stay with me dont let me go until the ashes of eden fall dont let go why cant i hear you stay with me dont let me go because theres nothing left at all stay with me dont let me go until the ashes of eden fall heaven above me take my hand stay with me dont let me go shine until theres nothing left but you heaven above me take my hand stay with me dont let me go shine until theres nothing left but you"
# # song = "this is the song it is a song"
# words = (set(song.split(' ')))
# # print(len(words)) # 80
#
#
# word_set = list(set(song.split(' ')))
# word_dic = {w: i for i, w in enumerate(word_set)}
#
# raw_text = song
# # create mapping of unique chars to integers, and a reverse mapping
# char_to_int = dict((c, i) for i, c in enumerate(words))
# int_to_char = dict((i, c) for i, c in enumerate(words))
#
# # summarize the loaded data
# n_chars = len(raw_text.split(' '))
# n_vocab = len(words)
# print("Total Words: ", n_chars)
# print("Total Vocab: ", n_vocab)
# # prepare the dataset of input to output pairs encoded as integers
# seq_length = 1
# dataX = []
# dataY = []
# for i in range(0, n_chars - seq_length, 1):
#     seq_in = raw_text[i:i + seq_length]
#     seq_out = raw_text[i + seq_length]
#     dataX.append([char_to_int[char] for char in seq_in])
#     dataY.append(char_to_int[seq_out])
# n_patterns = len(dataX)
# print("Total Patterns: ", n_patterns)
# # reshape X to be [samples, time steps, features]
# X = np.reshape(dataX, (n_patterns, seq_length, 1))
#
# # normalize
# X = X / float(n_vocab)
#
# # one hot encode the output variable
# y = np_utils.to_categorical(dataY)
#
# # define the LSTM model
# model = Sequential()
# model.add(LSTM(256, input_shape=(X.shape[1], X.shape[2])))
# model.add(Dropout(0.2))
# model.add(Dense(y.shape[1], activation='softmax'))
# # load the network weights
# filename = "weights-improvement-19-1.9435.hdf5"
# model.load_weights(filename)
# model.compile(loss='categorical_crossentropy', optimizer='adam')
# # pick a random seed
# start = np.random.randint(0, len(dataX) - 1)
# pattern = dataX[start]
# print("Seed:")
# print("\"", ''.join([int_to_char[value] for value in pattern]), "\"")
# # generate characters
# for i in range(100):
#     x = np.reshape(pattern, (1, len(pattern), 1))
#     x = x / float(n_vocab)
#     prediction = model.predict(x, verbose=0)
#     index = np.argmax(prediction)
#     result = int_to_char[index]
#     seq_in = [int_to_char[value] for value in pattern]
#     print(result)
#     pattern.append(index)
#     pattern = pattern[1:len(pattern)]
# print("\nDone.")
