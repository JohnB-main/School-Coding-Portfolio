# import tensorflow as tf
import matplotlib.pyplot as plt
import numpy as np
# possible command to fix issues ?
import tensorflow.compat.v1 as tf
# tf.disable_v2_behavior()
import os
os.environ['TF_CPP_MIN_LOG_LEVEL'] = '2'

'metacritic score influence on Normth American sales in terms of million'

'Loading Data From a File'

# slicing is helpful
''' [index (included) : index (not included)]
    # index start at 0
    # blank means first or last
    # -1 means end
'''

# for reproducibility
tf.set_random_seed(777)
data_path=r'C:\Users\Owner\Desktop\EKU\2020Fall\CSC546AI\NumbersGameDataSet.csv'
xy = np.loadtxt(data_path, delimiter=',', dtype=np.float32)
x_data = xy[:, [1]]
y_data = xy[:, [-1]]

# make sure the shape and data are ok
# print(x_data.shape, x_data, len(x_data))
# print(y_data.shape, y_data)


# placeholders for a tensor that will be always fed.
X = tf.placeholder(tf.float32, shape=[None, 1])
Y = tf.placeholder(tf.float32, shape=[None,1])
W = tf.Variable(tf.random_normal([1]), name='weight')
b = tf.Variable(tf.random_normal([1]), name = 'bias')

# hypothesis
hypothesis = X*W + b

# Simplified cost/Loss function
cost = tf.reduce_mean(tf.square(hypothesis - Y))

# minimize
optimizer = tf.train.GradientDescentOptimizer(learning_rate = 1e-5)
train = optimizer.minimize(cost)


# Launch the graph in a session
sess = tf.Session()
# Initializes global variables in the graph.
sess.run(tf.global_variables_initializer())
# set up feed_dict variables inside the loop.
for step in range(9001):
    cost_val, hy_val, _ = sess.run([cost, hypothesis, train], feed_dict = {X:x_data, Y: y_data})
    if step % 1000 == 0:
        print(step, "cost:", cost_val, "prediction", hy_val)




# #ask my score
print("Estimated North American Sales (million)", sess.run(hypothesis, feed_dict={X:[[95]]}))
# print("other scores will be", sess.run(hypothesis, feed_dict = {X:[[60, 70, 110], [90, 100, 80]]}))

# conclusion = there is no good correlation bettween the sore and the sales.

# try different rates, optimize data to exclude the 0s?