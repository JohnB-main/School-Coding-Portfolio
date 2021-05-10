import warnings
warnings.simplefilter(action='ignore', category=FutureWarning)
import tensorflow as tf
import matplotlib.pyplot as plt
import numpy as np
import random
import pprint as pp
from sklearn.preprocessing import MinMaxScaler

# possible command to fix issues ?
# import tensorflow as tf
# tf.disable_v2_behavior()
import os
os.environ['KMP_DUPLICATE_LIB_OK']='True'
tf.set_random_seed(777)

# # mnist stuff for import and use
from tensorflow.examples.tutorials.mnist import input_data
mnist = input_data.read_data_sets("MNIST_data/", one_hot=True)



'''10/052020'''
'''
Neural Nets

CIFAR = Canadian center for advanced research

np.array
    can be multidim
    RANK
        use arrrName.ndim
    SHAPE
        name.shape 
    Element
        Name[5]
    slicing
        name[2:4]
        includes first excludes last
    
    Rank is same as number of axis
    
'''

'''10/07/2020'''

'''
Basic Derivative 
    take in relation to x or y
    lower power of taking and keep constant
    x^2 become 2x
    2x becomes 2
    xy becomes y
    2 becomes 0
    
Chain Rule
    get inside derivative and then outside
    useful for back propogation
    
XOR NEURAL NETWORKS
    need 2 or more logic class units to solve
    using the two logits with inputs being W, then sigmoiding the result
        this results in 0 or 1 in the results
        the same result means the prediction should be true
        opposite means it is false
        The above is forward propogation, i think?
    
    USING ONLY 2 LOGITS
        K(x) is also known as the hypothesis
        hypo of one goes into input for second function
        K = tf.sigmoid(tf.matmul(X, W1) + b
        
    WITH NEURAL NETOWRKS
        input layer
        hidden layer 1
        hidden layer 2
        output layer
        need to know how each node affected the one after
            done through derivative
            back propogation
        
        f = wx +b
        g = wx
        f = g+b
        
        x--\
            --(*)g---
        w--/          \
                        (+) --- f
        b-------------/
        
'''

# # # must use a neural netowrk to solve issue
# x_data = np.array( [ [0,0], [0,1], [1,0], [1,1] ] , dtype = np.float32 )
# y_data = np.array( [ [0], [1], [1], [0] ], dtype = np.float32 )
#
# X = tf.placeholder(tf.float32)
# Y = tf.placeholder(tf.float32)
# W1 = tf.Variable(tf.random_normal([2,2]), name='weight1')
# b1 = tf.Variable(tf.random_normal([2]), name='bias1')
# layer1 = tf.sigmoid(tf.matmul(X, W1) + b1)
# W2 = tf.Variable(tf.random_normal([2,1]), name='weight2')
# b2 = tf.Variable(tf.random_normal([1]), name='bias2')
# hypothesis = tf.sigmoid(tf.matmul(layer1,W2) + b2)
#
# cost = -tf.reduce_mean(Y*tf.log(hypothesis)+(1-Y)*tf.log(1-hypothesis))
# train = tf.train.GradientDescentOptimizer(learning_rate=0.1).minimize(cost)
#
# predicted = tf.cast(hypothesis > 0.5, dtype=tf.float32)
# accuracy = tf.reduce_mean(tf.cast(tf.equal(predicted, Y), dtype=tf.float32))
#
# # launch graph
# with tf.Session() as sess:
#     #initialize TensorFlow variables
#     sess.run(tf.global_variables_initializer())
#     for step in range(10001):
#         sess.run(train, feed_dict={X: x_data, Y: y_data})
#         # if step % 100 == 0:
#             # print(step, sess.run(cost, feed_dict={X: x_data, Y: y_data}), sess.run([W1,W2]))
# #Acuuracy report
#     h, c, a = sess.run([hypothesis, predicted, accuracy], feed_dict={X: x_data, Y: y_data})
#     print("Hypothesis:", h, "Correct:", c, "Accuracy:", a)




'''10/12/2020'''
'''
Deep and Wide NNs
'''

# x_data = np.array( [ [0,0], [0,1], [1,0], [1,1] ] , dtype = np.float32 )
# y_data = np.array( [ [0], [1], [1], [0] ], dtype = np.float32 )
#
# X = tf.placeholder(tf.float32)
# Y = tf.placeholder(tf.float32)
#
# W1 = tf.Variable(tf.random_normal([2,10]), name='weight1')
# b1 = tf.Variable(tf.random_normal([10]), name='bias1')
# layer1 = tf.sigmoid(tf.matmul(X, W1) + b1)
#
# W2 = tf.Variable(tf.random_normal([2,10]), name='weight1')
# b2 = tf.Variable(tf.random_normal([10]), name='bias1')
# layer2 = tf.sigmoid(tf.matmul(layer1, W2) + b2)
#
# W3 = tf.Variable(tf.random_normal([2,10]), name='weight1')
# b3 = tf.Variable(tf.random_normal([10]), name='bias1')
# layer3 = tf.sigmoid(tf.matmul(layer2, W3) + b3)
#
# W4 = tf.Variable(tf.random_normal([2,10]), name='weight1')
# b4 = tf.Variable(tf.random_normal([10]), name='bias1')
# layer4 = tf.sigmoid(tf.matmul(layer3, W4) + b4)
#
# hypothesis = tf.sigmoid(tf.matmul(layer4,W4) + b4)
#
# cost = -tf.reduce_mean(Y*tf.log(hypothesis)+(1-Y)*tf.log(1-hypothesis))
# train = tf.train.GradientDescentOptimizer(learning_rate=0.1).minimize(cost)
#
# predicted = tf.cast(hypothesis > 0.5, dtype=tf.float32)
# accuracy = tf.reduce_mean(tf.cast(tf.equal(predicted, Y), dtype=tf.float32))
#
# # launch graph
# with tf.Session() as sess:
#     #initialize TensorFlow variables
#     sess.run(tf.global_variables_initializer())
#     for step in range(10001):
#         sess.run(train, feed_dict={X: x_data, Y: y_data})
#         # if step % 100 == 0:
#             # print(step, sess.run(cost, feed_dict={X: x_data, Y: y_data}), sess.run([W1,W2]))
# #Acuuracy report
#     h, c, a = sess.run([hypothesis, predicted, accuracy], feed_dict={X: x_data, Y: y_data})
#     print("Hypothesis:", h, "Correct:", c, "Accuracy:", a)


'NMIST Version'
# # doing stuff with MNIST
# # classification with softmax; comparing accuracy between sofrmax and NN
# # EDIT CORRECT THIS TOO, WEIRD CODE; should spit out 90%, softmax does 89
# from tensorflow.examples.tutorials.mnist import input_data
# # Check out https://www.tensorflow.org/get_started/mnist/beginners for
# # more information about the mnist dataset
# mnist = input_data.read_data_sets("MNIST_data/", one_hot=True)
# nb_classes = 10
# # MNIST data image of shape 28 * 28 = 784
# X = tf.placeholder(tf.float32, [None, 784])
# # 0 - 9 digits recognition = 10 classes
# Y = tf.placeholder(tf.float32, [None, nb_classes])
#
# W1 = tf.Variable(tf.random_normal([784, 10]))
# b1 = tf.Variable(tf.random_normal([10]))
# layer1 = tf.nn.softmax(tf.matmul(X, W1) + b1)
#
# W2 = tf.Variable(tf.random_normal([10, 5]))
# b2 = tf.Variable(tf.random_normal([5]))
# layer2 = tf.nn.softmax(tf.matmul(layer1, W2) + b2)
#
# W3 = tf.Variable(tf.random_normal([5, 3]))
# b3 = tf.Variable(tf.random_normal([3]))
# layer3 = tf.nn.softmax(tf.matmul(layer2, W3) + b3)
#
# W4 = tf.Variable(tf.random_normal([3, nb_classes]))
# b4 = tf.Variable(tf.random_normal([nb_classes]))
# hypothesis = tf.nn.softmax(tf.matmul(layer3, W4) + b4)
#
# cost = tf.reduce_mean(-tf.reduce_sum(Y * tf.log(hypothesis), axis=1))
# optimizer = tf.train.GradientDescentOptimizer(learning_rate=0.001).minimize(cost)
# # Test model
# is_correct = tf.equal(tf.arg_max(hypothesis, 1), tf.arg_max(Y, 1))
# # Calculate accuracy
# accuracy = tf.reduce_mean(tf.cast(is_correct, tf.float32))
#
#
# num_epochs = 15
# batch_size = 100
# num_iterations = int(mnist.train.num_examples/batch_size)
# with tf.Session() as sess:
#     sess.run(tf.global_variables_initializer())
#     # Training cycle
#     for epoch in range(num_epochs):
#         avg_cost = 0
#         for i in range(num_iterations):
#             batch_xs, batch_ys = mnist.train.next_batch(batch_size)
#             c, _ = sess.run([cost, optimizer], feed_dict={X: batch_xs, Y: batch_ys})
#             avg_cost += c / num_iterations
#         print("Epoch: {:04d}, Cost: {:.9f}".format(epoch + 1, avg_cost))
#
#
#     print("Accuracy: ",accuracy.eval(session=sess, feed_dict={X: mnist.test.images, Y: mnist.test.labels}))
#
#     # Get one and predict
#     r = random.randint(0, mnist.test.num_examples - 1)
#     print("Label: ", sess.run(tf.argmax(mnist.test.labels[r : r + 1], 1)))
#     print("Prediction: ", sess.run(tf.argmax(hypothesis, 1), feed_dict={X: mnist.test.images[r : r + 1]}))
#     plt.imshow(mnist.test.images[r : r + 1].reshape(28, 28),cmap="Greys", interpolation="nearest")
#     plt.show()

'''10/14/2020'''
'''
TENSOR BOARD

Takes 5 steps

scalar or histogram

define layers with scope



'''


# x_data = np.array([[0,0],[0,1],[1,0],[1,1]], dtype = np.float32)
# y_data = np.array([[0],[1],[1],[0]], dtype=np.float32)
# X = tf.placeholder(tf.float32, [None, 2], name = "x")
# Y = tf.placeholder(tf.float32, [None, 1], name = "y")
#
# with tf.name_scope("layer1") as scope:
#     W1 = tf.Variable(tf.random_normal([2,2]), name='weight_1')
#     b1 = tf.Variable(tf.random_normal([2]), name='bias_1')
#     layer1 = tf.sigmoid(tf.matmul(X, W1) + b1)
#     w1_hist = tf.summary.histogram("W1", W1)
#     b1_hist = tf.summary.histogram("b1", b1)
#     layer1_hist = tf.summary.histogram("layer1", layer1)
#
# with tf.name_scope("layer2") as scope:
#     W2 = tf.Variable(tf.random_normal([2,1]), name='weight_2')
#     b2 = tf.Variable(tf.random_normal([1]), name='bias_2')
#     hypothesis = tf.sigmoid(tf.matmul(layer1, W2) + b2)
#     W2_hist = tf.summary.histogram("W2", W2)
#     b2_hist = tf.summary.histogram("b2", b2)
#     hypothesis_hist = tf.summary.histogram("hypothesis", hypothesis)
#
# # cost/Loss function
# with tf.name_scope("cost") as scope:
#     cost = -tf.reduce_mean(Y*tf.log(hypothesis)+(1-Y)*tf.log(1-hypothesis))
#     cost_scalar = tf.summary.scalar("cost", cost)
# with tf.name_scope("train") as scope:
#     train = tf.train.AdamOptimizer(learning_rate=0.1).minimize(cost)
#     # tf.summary.scalar("train", train)
#
# # Accuracy computation : True if hypothesis >0.5 else False
# predicted = tf.cast(hypothesis > 0.5, dtype=tf.float32)
# accuracy = tf.reduce_mean(tf.cast(tf.equal(predicted, Y), dtype=tf.float32))
# accuracy_scalar = tf.summary.scalar("accuracy", accuracy)
#
# # Launch graph
# with tf.Session() as sess:
#     # summary
#     merged_summary = tf.summary.merge_all()
#     # create summary writer; makes a folder that log files will go into
#     writer = tf.summary.FileWriter(r"C:\Users\Owner\Desktop\EKU\2020Fall\CSC546AI\AI Python Codes\xor_logs_r01")
#     writer.add_graph(sess.graph) # Show the graph
#     # Initialize TensorFlow variables
#     sess.run(tf.global_variables_initializer())
#     for step in range(10001):
#         _, summary, cost_val = sess.run([train, merged_summary, cost], feed_dict={X: x_data, Y: y_data})
#         writer.add_summary(summary, global_step=step)
#         if step % 100 == 0:
#             print(step, cost_val)
#     # Accuracy report
#     h, p, a = sess.run([hypothesis, predicted, accuracy], feed_dict={X: x_data, Y: y_data})
#     print("Hypothesis:{}\n predicted:{}\n Accuracy:{}\n".format(h, p, a))

'''
RUNNING IN CLI
    Use a command in pycharm terminal to start and be able to see the results
    similar to below...
    tensorboard --logdir "C:/Users/Owner/Desktop/EKU/2020Fall/CSC546AI/AI Python Codes/xor_logs_r01"
    
    can be shotened to (if in the directory in terminal) ...
    
    tensorboard --logdir xor_logs_r01

    
    Then go to...
    localhost:6006
    
    to be able to see the graphs and such    
'''
#
# # tensorboard --logdir="your directory" --port 6006
# # need to open terminal at log and activate env
# # user mnist and use tensorBoard and NN Due sunday; basically what we did in class
# # add 2 more layers
#
# mnist = input_data.read_data_sets("MNIST_data/", one_hot=True)
# nb_classes = 10
#
# X = tf.placeholder(tf.float32, [None, 784])
# Y = tf.placeholder(tf.float32, [None, nb_classes])
#
# with tf.name_scope("layer1") as scope:
#     W1 = tf.Variable(tf.random_normal([784, 10]))
#     b1 = tf.Variable(tf.random_normal([10]))
#     layer1 = tf.nn.softmax(tf.matmul(X, W1) + b1)
#     w1_hist = tf.summary.histogram("W1", W1)
#     b1_hist = tf.summary.histogram("b1", b1)
#     layer1_hist = tf.summary.histogram("layer1", layer1)
#
# with tf.name_scope("layer2") as scope:
#     W2 = tf.Variable(tf.random_normal([10, 5]))
#     b2 = tf.Variable(tf.random_normal([5]))
#     layer2 = tf.nn.softmax(tf.matmul(layer1, W2) + b2)
#     w2_hist = tf.summary.histogram("W2", W2)
#     b2_hist = tf.summary.histogram("b2", b2)
#     layer2_hist = tf.summary.histogram("layer2", layer2)
#
# with tf.name_scope("layer3") as scope:
#     W3 = tf.Variable(tf.random_normal([5, 3]))
#     b3 = tf.Variable(tf.random_normal([3]))
#     layer3 = tf.nn.softmax(tf.matmul(layer2, W3) + b3)
#     w3_hist = tf.summary.histogram("W3", W3)
#     b3_hist = tf.summary.histogram("b3", b3)
#     layer3_hist = tf.summary.histogram("layer3", layer1)
#
# with tf.name_scope("layer4") as scope:
#     W4 = tf.Variable(tf.random_normal([3, nb_classes]))
#     b4 = tf.Variable(tf.random_normal([nb_classes]))
#     hypothesis = tf.nn.softmax(tf.matmul(layer3, W4) + b4)
#     w4_hist = tf.summary.histogram("W4", W4)
#     b4_hist = tf.summary.histogram("b4", b4)
#     hypothesis_hist = tf.summary.histogram("hypothesis", hypothesis)
#
# cost = tf.reduce_mean(-tf.reduce_sum(Y * tf.log(hypothesis), axis=1))
# optimizer = tf.train.GradientDescentOptimizer(learning_rate=0.1).minimize(cost)
#
# # Test model
# is_correct = tf.equal(tf.arg_max(hypothesis, 1), tf.arg_max(Y, 1))
# # Calculate accuracy
# accuracy = tf.reduce_mean(tf.cast(is_correct, tf.float32))
#
#
# num_epochs = 15
# batch_size = 100
# num_iterations = int(mnist.train.num_examples/batch_size)
# with tf.Session() as sess:
#     # summary
#     merged_summary = tf.summary.merge_all()
#     # create summary writer; makes a folder that log files will go into
#     # tensorboard --logdir mnistStuff
#     writer = tf.summary.FileWriter(r"C:\Users\Owner\Desktop\EKU\2020Fall\CSC546AI\AI Python Codes\mnistStuff")
#     writer.add_graph(sess.graph) # Show the graph
#     sess.run(tf.global_variables_initializer())
#     # Training cycle
#     for epoch in range(num_epochs):
#         avg_cost = 0
#         for i in range(num_iterations):
#             batch_xs, batch_ys = mnist.train.next_batch(batch_size)
#
#             c, _ , summary= sess.run([cost, optimizer, merged_summary], feed_dict={X: batch_xs, Y: batch_ys})
#             writer.add_summary(summary, global_step=i)
#             avg_cost += c / num_iterations
#         print("Epoch: {:04d}, Cost: {:.9f}".format(epoch + 1, avg_cost))
#
#
#     print("Accuracy: ", accuracy.eval(session=sess, feed_dict={X: mnist.test.images, Y: mnist.test.labels}))

'''10/18/2020 Class Missed Makeup
NEEDS CORRECTION
'''
# x_data = np.array([[0,0],[0,1],[1,0],[1,1]], dtype = np.float32)
# y_data = np.array([[0],[1],[1],[0]], dtype=np.float32)
#
# X = tf.placeholder(tf.float32)
# Y = tf.placeholder(tf.float32)
#
# with tf.name_scope("layer1") as scope:
#     W1 = tf.Variable(tf.random_normal([2,5]), name='weight1')
#     b1 = tf.Variable(tf.random_normal([5]), name='bias1')
#     layer1 = tf.nn.relu(tf.matmul(X, W1) + b1)
#
#     w1_hist = tf.summary.histogram("W1", W1)
#     b1_hist = tf.summary.histogram("b1", b1)
#     layer1_hist = tf.summary.histogram("layer1", layer1)
#
# with tf.name_scope("layer2") as scope:
#     W2 = tf.Variable(tf.random_normal([5,5]), name='weight2')
#     b2 = tf.Variable(tf.random_normal([5]), name='bias2')
#     layer2 = tf.nn.relu(tf.matmul(layer1, W2) + b2)
#
#     w2_hist = tf.summary.histogram("W2", W2)
#     b2_hist = tf.summary.histogram("b2", b2)
#     layer2_hist = tf.summary.histogram("layer2", layer2)
#
# with tf.name_scope("layer3") as scope:
#     W3 = tf.Variable(tf.random_normal([5,5]), name='weight3')
#     b3 = tf.Variable(tf.random_normal([5]), name='bias3')
#     layer3 = tf.nn.relu(tf.matmul(layer2, W3) + b3)
#
#     w3_hist = tf.summary.histogram("W3", W3)
#     b3_hist = tf.summary.histogram("b3", b3)
#     layer3_hist = tf.summary.histogram("layer3", layer3)
#
# with tf.name_scope("layer4") as scope:
#     W4 = tf.Variable(tf.random_normal([5,5]), name='weight4')
#     b4 = tf.Variable(tf.random_normal([5]), name='bias4')
#     layer4 = tf.nn.relu(tf.matmul(layer3, W4) + b4)
#
#     w4_hist = tf.summary.histogram("W4", W4)
#     b4_hist = tf.summary.histogram("b4", b4)
#     layer4_hist = tf.summary.histogram("layer4", layer4)
#
# with tf.name_scope("layer5") as scope:
#     W5 = tf.Variable(tf.random_normal([5,5]), name='weight5')
#     b5 = tf.Variable(tf.random_normal([5]), name='bias5')
#     layer5 = tf.nn.relu(tf.matmul(layer4, W5) + b5)
#
#     w5_hist = tf.summary.histogram("W5", W5)
#     b5_hist = tf.summary.histogram("b5", b5)
#     layer5_hist = tf.summary.histogram("layer5", layer5)
#
# with tf.name_scope("layer6") as scope:
#     W6 = tf.Variable(tf.random_normal([5,5]), name='weight6')
#     b6 = tf.Variable(tf.random_normal([5]), name='bias6')
#     layer6 = tf.nn.relu(tf.matmul(layer5, W6) + b6)
#
#     w6_hist = tf.summary.histogram("W6", W6)
#     b6_hist = tf.summary.histogram("b6", b6)
#     layer6_hist = tf.summary.histogram("layer6", layer6)
#
# with tf.name_scope("layer7") as scope:
#     W7 = tf.Variable(tf.random_normal([5,5]), name='weight7')
#     b7 = tf.Variable(tf.random_normal([5]), name='bias7')
#     layer7 = tf.nn.relu(tf.matmul(layer6, W7) + b7)
#
#     w7_hist = tf.summary.histogram("W7", W7)
#     b7_hist = tf.summary.histogram("b7", b7)
#     layer7_hist = tf.summary.histogram("layer7", layer7)
#
# with tf.name_scope("layer8") as scope:
#     W8 = tf.Variable(tf.random_normal([5,5]), name='weight8')
#     b8 = tf.Variable(tf.random_normal([5]), name='bias8')
#     layer8 = tf.nn.relu(tf.matmul(layer7, W8) + b8)
#
#     w8_hist = tf.summary.histogram("W8", W8)
#     b8_hist = tf.summary.histogram("b8", b8)
#     layer8_hist = tf.summary.histogram("layer8", layer8)
#
# with tf.name_scope("layer9") as scope:
#     W9 = tf.Variable(tf.random_normal([5,5]), name='weight9')
#     b9 = tf.Variable(tf.random_normal([5]), name='bias9')
#     layer9 = tf.nn.relu(tf.matmul(layer8, W9) + b9)
#
#     w9_hist = tf.summary.histogram("W9", W9)
#     b9_hist = tf.summary.histogram("b9", b9)
#     layer9_hist = tf.summary.histogram("layer9", layer9)
#
# with tf.name_scope("layer10") as scope:
#     W10 = tf.Variable(tf.random_normal([5,5]), name='weight10')
#     b10 = tf.Variable(tf.random_normal([5]), name='bias10')
#     layer10 = tf.nn.relu(tf.matmul(layer9, W10) + b10)
#
#     w10_hist = tf.summary.histogram("W10", W10)
#     b10_hist = tf.summary.histogram("b10", b10)
#     layer10_hist = tf.summary.histogram("layer10", layer10)
#
# with tf.name_scope("last") as scope:
#     W11 = tf.Variable(tf.random_normal([5,1]), name='weight4')
#     b11 = tf.Variable(tf.random_normal([1]), name='bias4')
#     hypothesis = tf.sigmoid(tf.matmul(layer10,W11) + b11)
#
#     w11_hist = tf.summary.histogram("W11", W11)
#     b11_hist = tf.summary.histogram("b11", b11)
#     hypothesis_hist = tf.summary.histogram("hypothesis", hypothesis)
#
# # cost/Loss function
# with tf.name_scope("cost") as scope:
#     cost = -tf.reduce_mean(Y*tf.log(hypothesis + 1e-8)+(1-Y)*tf.log(1-hypothesis + 1e-8))
#     cost_scalar = tf.summary.scalar("cost", cost)
#
# with tf.name_scope("train") as scope:
#     train = tf.train.GradientDescentOptimizer(learning_rate=0.01).minimize(cost)
#
# # Accuracy computation
# # True if hypothesis >0.5 else False
# predicted = tf.cast(hypothesis > 0.5, dtype=tf.float32)
# accuracy = tf.reduce_mean(tf.cast(tf.equal(predicted, Y), dtype=tf.float32))
# tf.summary.scalar("accuracy", accuracy)
#
# # Launch graph
# with tf.Session() as sess:
#     # summary
#     merged_summary = tf.summary.merge_all()
#     # create summary writer
#     writer = tf.summary.FileWriter(r"C:\Users\Owner\Desktop\EKU\2020Fall\CSC546AI\AI Python Codes\mnistStuff")
#     writer.add_graph(sess.graph)  # Show the graph
#
#     #Initialize TensorFlow variables
#     sess.run(tf.global_variables_initializer())
#
#     for step in range(10001):
#         _, summary, cost_val = sess.run([train, merged_summary, cost], feed_dict={X: x_data, Y: y_data})
#         writer.add_summary(summary, global_step=step)
#
#         #sess.run(train, feed_dict={X: x_data, Y: y_data})
#         #if step % 100 == 0:
#         #    print(step, sess.run(cost, feed_dict={X: x_data, Y: y_data}), sess.run([W1,W2]))
#         if step % 100 == 0:
#             print(step, cost_val)
#
#     # Accuracy report
#     h,c,a = sess.run([hypothesis, predicted, accuracy], feed_dict={X: x_data, Y: y_data})
#     print("Hypothesis:",h, "Correct:",c, "Accuracy:",a)

'''10/21/2020'''
'''
Another way to do ReLU

Restricted Boatzman Machine (RBM) 
    no connection between same layer
    very complicated
    
Xavier Initialization
    num of input to num of outputs
    W = np.random( in,out )/ sqrt(in)
    
 THIS HAS THE CORRECT ACCURACY FOR IT, BASE CODE OFF THIS
 This is the xavier version
'''
# # parameters
# learning_rate = 0.001
# training_epochs = 15
# batch_size = 100
#
# # input place holders
# X = tf.placeholder(tf.float32, [None, 784])
# Y = tf.placeholder(tf.float32, [None, 10])
#
#
# # weights & bias for nn layers
# # http://stackoverflow.com/questions/33640581/how-to-do-xavier-initialization-on-tensorflow
# with tf.name_scope("L1") as scope:
#     W1 = tf.get_variable("W1", shape=[784, 256],
#                          initializer=tf.contrib.layers.xavier_initializer())
#     b1 = tf.Variable(tf.random_normal([256]))
#     L1 = tf.nn.relu(tf.matmul(X, W1) + b1)
#
#     w1_hist = tf.summary.histogram("W1", W1)
#     b1_hist = tf.summary.histogram("b1", b1)
#     L1_hist = tf.summary.histogram("L1", L1)
#
# with tf.name_scope("L2") as scope:
#     W2 = tf.get_variable("W2", shape=[256, 256],
#                          initializer=tf.contrib.layers.xavier_initializer())
#     b2 = tf.Variable(tf.random_normal([256]))
#     L2 = tf.nn.relu(tf.matmul(L1, W2) + b2)
#     w2_hist = tf.summary.histogram("W2", W2)
#     b2_hist = tf.summary.histogram("b2", b2)
#     L2_hist = tf.summary.histogram("L2", L2)
#
# with tf.name_scope("hypothesis") as scope:
#     W3 = tf.get_variable("W3", shape=[256, 10],
#                          initializer=tf.contrib.layers.xavier_initializer())
#     b3 = tf.Variable(tf.random_normal([10]))
#     hypothesis = tf.matmul(L2, W3) + b3
#
#     w3_hist = tf.summary.histogram("W3", W3)
#     b3_hist = tf.summary.histogram("b3", b3)
#     hypothesis_hist = tf.summary.histogram("hypothesis", hypothesis)
#
# # define cost/loss & optimizer
# cost = tf.reduce_mean(tf.nn.softmax_cross_entropy_with_logits(
#     logits=hypothesis, labels=Y))
# optimizer = tf.train.AdamOptimizer(learning_rate=learning_rate).minimize(cost)
#
# # initialize
# sess = tf.Session()
#
#
# merged_summary = tf.summary.merge_all()
# # create summary writer; makes a folder that log files will go into
# # tensorboard --logdir mnistStuff
# writer = tf.summary.FileWriter(r"C:\Users\Owner\Desktop\EKU\2020Fall\CSC546AI\AI Python Codes\XavierReport")
# writer.add_graph(sess.graph) # Show the graph
#
# sess.run(tf.global_variables_initializer())
#
# # train my model
# for epoch in range(training_epochs):
#     avg_cost = 0
#     total_batch = int(mnist.train.num_examples / batch_size)
#
#     for i in range(total_batch):
#         batch_xs, batch_ys = mnist.train.next_batch(batch_size)
#         feed_dict = {X: batch_xs, Y: batch_ys}
#         c, _, summary = sess.run([cost, optimizer, merged_summary], feed_dict=feed_dict)
#         writer.add_summary(summary, global_step=i)
#         avg_cost += c / total_batch
#
#     print('Epoch:', '%04d' % (epoch + 1), 'cost =', '{:.9f}'.format(avg_cost))
#
# print('Learning Finished!')
#
# # Test model and check accuracy
# correct_prediction = tf.equal(tf.argmax(hypothesis, 1), tf.argmax(Y, 1))
# accuracy = tf.reduce_mean(tf.cast(correct_prediction, tf.float32))
# print('Accuracy:', sess.run(accuracy, feed_dict={X: mnist.test.images, Y: mnist.test.labels}))

# # Get one and predict
# r = random.randint(0, mnist.test.num_examples - 1)
# print("Label: ", sess.run(tf.argmax(mnist.test.labels[r:r + 1], 1)))
# print("Prediction: ", sess.run(
#     tf.argmax(hypothesis, 1), feed_dict={X: mnist.test.images[r:r + 1]}))

# plt.imshow(mnist.test.images[r:r + 1].
#           reshape(28, 28), cmap='Greys', interpolation='nearest')
# plt.show()


# drop out can be added to training, not testing

''''
REPORT DUE SUNDAY 
    USE ADAM OPTIMIZER
    DRAW GRAPH WITH CIRCLES ON IT?
    MAYBE USING TENSORBOARD?
'''
'Dropout in learning and testing'

# # parameters
# learning_rate = 0.001
# training_epochs = 15
# batch_size = 100
#
# # input place holders
# X = tf.placeholder(tf.float32, [None, 784])
# Y = tf.placeholder(tf.float32, [None, 10])
#
#
# # weights & bias for nn layers
# # http://stackoverflow.com/questions/33640581/how-to-do-xavier-initialization-on-tensorflow
#
# # dropout (keep_prob) rate 0.7 on training, but should be 1 for testing
# keep_prob = tf.placeholder(tf.float32)
#
# with tf.name_scope("L1") as scope:
#     W1 = tf.get_variable("W1", shape=[784, 256],
#                          initializer=tf.contrib.layers.xavier_initializer())
#     b1 = tf.Variable(tf.random_normal([256]))
#     L1 = tf.nn.relu(tf.matmul(X, W1) + b1)
#
#     w1_hist = tf.summary.histogram("W1", W1)
#     b1_hist = tf.summary.histogram("b1", b1)
#     L1_hist = tf.summary.histogram("L1", L1)
#
#     L1 = tf.nn.dropout(L1, keep_prob=keep_prob)
#
# with tf.name_scope("L2") as scope:
#     W2 = tf.get_variable("W2", shape=[256, 256],
#                          initializer=tf.contrib.layers.xavier_initializer())
#     b2 = tf.Variable(tf.random_normal([256]))
#     L2 = tf.nn.relu(tf.matmul(L1, W2) + b2)
#     w2_hist = tf.summary.histogram("W2", W2)
#     b2_hist = tf.summary.histogram("b2", b2)
#     L2_hist = tf.summary.histogram("L2", L2)
#
#     L2 = tf.nn.dropout(L2, keep_prob=keep_prob)
#
# with tf.name_scope("hypothesis") as scope:
#     W3 = tf.get_variable("W3", shape=[256, 10],
#                          initializer=tf.contrib.layers.xavier_initializer())
#     b3 = tf.Variable(tf.random_normal([10]))
#     hypothesis = tf.matmul(L2, W3) + b3
#
#     w3_hist = tf.summary.histogram("W3", W3)
#     b3_hist = tf.summary.histogram("b3", b3)
#     hypothesis_hist = tf.summary.histogram("hypothesis", hypothesis)
#
#     hypothesis = tf.nn.dropout(hypothesis, keep_prob=keep_prob)
#
# # define cost/loss & optimizer
# cost = tf.reduce_mean(tf.nn.softmax_cross_entropy_with_logits(
#     logits=hypothesis, labels=Y))
# optimizer = tf.train.AdamOptimizer(learning_rate=learning_rate).minimize(cost)
#
# # initialize
# sess = tf.Session()
#
#
# merged_summary = tf.summary.merge_all()
# # create summary writer; makes a folder that log files will go into
# # tensorboard --logdir mnistStuff
# writer = tf.summary.FileWriter(r"C:\Users\Owner\Desktop\EKU\2020Fall\CSC546AI\AI Python Codes\XavierReport")
# writer.add_graph(sess.graph) # Show the graph
#
# sess.run(tf.global_variables_initializer())
#
# # train my model
# for epoch in range(training_epochs):
#     avg_cost = 0
#     total_batch = int(mnist.train.num_examples / batch_size)
#
#     for i in range(total_batch):
#         batch_xs, batch_ys = mnist.train.next_batch(batch_size)
#         feed_dict = {X: batch_xs, Y: batch_ys, keep_prob: 0.7}
#         c, _, summary = sess.run([cost, optimizer, merged_summary], feed_dict=feed_dict)
#         writer.add_summary(summary, global_step=i)
#         avg_cost += c / total_batch
#
#     print('Epoch:', '%04d' % (epoch + 1), 'cost =', '{:.9f}'.format(avg_cost))
#
# print('Learning Finished!')
#
# # Test model and check accuracy
# correct_prediction = tf.equal(tf.argmax(hypothesis, 1), tf.argmax(Y, 1))
# accuracy = tf.reduce_mean(tf.cast(correct_prediction, tf.float32))
# print('Accuracy:', sess.run(accuracy, feed_dict={X: mnist.test.images, Y: mnist.test.labels, keep_prob:1}))

'''10/26/2020
CNN Conversion NN

Wednesday is 2nd Exam
    she will give study guide
    4:50 question
    6:05 send answers on Wednesday'''
'''
Foreward NN is all one line
Convolutional NN has conversion in its layers
    gets an image with length x width x rgb
    split the image into pieces, RBG will be the same
    similar to multiple variable
    go through all the portions of the image
    this makes a new grid of n X m
    keeps making a new grid
    
    common to pad the outside of an image in 0
        prevents picture form sharp decrease
        let you know where the edge is
    
    new = (original - filter size)/stride +1
    
    weight variable number = new size * new size * rgb * filters
    
     
    using multiple filters creates a convolution layer (image gets bigger)
        means we need to resize the layer (sampling) MaxPool
        
    using with tensorflow
'''

# sess = tf.InteractiveSession()
# image = np.array([
#     [
#         [[1],[2],[3]],
#         [[4],[5],[6]],
#         [[7],[8],[9]]
#      ]
# ], dtype=np.float32)
#
# print(image.shape)
# weight = tf.constant([[[[1.]], [[1.]]], [[[1.]], [[1.]]]])
# print(weight.shape)
# conv2d = tf.nn.conv2d(image, weight, strides=[1,1,1,1], padding='SAME')
# conv2d_img = conv2d.eval()
# print(conv2d_img.shape)
# conv2d_img = np.swapaxes(conv2d_img, 0, 3)
# for i, one_img in enumerate(conv2d_img):
#     print(one_img.reshape(3,3))
#     plt.subplot(1,2,i+1), plt.imshow(one_img.reshape(3,3), cmap='Greys')
#     plt.show()
# print('DONE!')



'''11/2/2020'''


# # more than one filter for CNN

# sess = tf.InteractiveSession()
# image = np.array([
#     [
#         [[1],[2],[3]],
#         [[4],[5],[6]],
#         [[7],[8],[9]]
#      ]
# ], dtype=np.float32)
#
# print(image.shape)
# weight = tf.constant([[[[1., 10., -1.]], [[1., 10., -1.]]], [[[1., 10., -1.]], [[1., 10., -1.]]]])
# print(weight.shape)
# conv2d = tf.nn.conv2d(image, weight, strides=[1,1,1,1], padding='SAME')
# conv2d_img = conv2d.eval()
# print(conv2d_img.shape)
# conv2d_img = np.swapaxes(conv2d_img, 0, 3)
# for i, one_img in enumerate(conv2d_img):
#     print(one_img.reshape(3,3))
#     plt.subplot(1,3,i+1), plt.imshow(one_img.reshape(3,3), cmap='Greys') #change to 3 for multiple images
#     plt.show()
# print('DONE!')

'mnist with CNN; NEEDS WORK'
# img = mnist.train.images[0].reshape(28,28)
# plt.imshow(img, cmap='gray')
#
# sess = tf.InteractiveSession()
# img = img.reshape(-1,28,28,1)
# W1 = tf.Variable(tf.random_normal([3,3,1,5], stddev=0.01))
# conv2d = tf.nn.conv2d(img, W1, strides=[1,2,2,1], padding='SAME')
# pool = tf.nn.max_pool(conv2d, ksize=[1,2,2,1], strides=[1,2,2,1], padding='SAME')
# print(pool)
# sess.run(tf.global_variables_initializer())
# conv2d_img = conv2d.eval()
# print(conv2d_img.shape)
# conv2d_img = np.swapaxes(conv2d_img, 0, 3)
# for i, one_img in enumerate(conv2d_img):
#     plt.subplot(1,5,i+1), plt.imshow(one_img.reshape(7,7), cmap='Greys')
#     plt.show()
# print('DONE!')

#
# training_epochs = 15
# batch_size = 100
#
# X= tf.placeholder(tf.float32, [None, 784])
#
# img = mnist.train.images[0].reshape(28,28)
# X_img = img.reshape(-1,28,28,1)
# Y= tf.placeholder(tf.float32, [None, 10])
#
# W1 = tf.Variable(tf.random_normal([3,3,1,32], stddev=0.01))
#
# L1 = tf.nn.conv2d(X_img, W1, strides=[1,1,1,1], padding='SAME')
# L1 = tf.nn.relu(L1)
# L1 = tf.nn.max_pool(L1, ksize=[1,2,2,1], strides=[1,2,2,1], padding='SAME')
#
#
#
# W2 = tf.Variable(tf.random_normal([3,3,32,64], stddev=0.01))
#
# L2 = tf.nn.conv2d(L1, W2, strides=[1,1,1,1], padding='SAME')
# L2 = tf.nn.relu(L2)
# L2 = tf.nn.max_pool(L2, ksize=[1,2,2,1], strides=[1,2,2,1], padding='SAME')
# L2_flat = tf.reshape(L2, [-1,7*7*64])
#
# W3 = tf.get_variable("W3", shape=[7*7*64,10], initializer=tf.contrib.layers.xavier_initializer())
# b = tf.Variable(tf.random_normal([10]))
# logits = tf.matmul(L2_flat, W3) + b
#
# cost = tf.reduce_mean(tf.nn.softmax_cross_entropy_with_logits(
#     logits=logits, labels=Y))
# optimizer = tf.train.AdamOptimizer(learning_rate=0.01).minimize(cost)
#
# sess=tf.Session()
# sess.run(tf.global_variables_initializer())
#
# # train my model
# for epoch in range(training_epochs):
#     avg_cost = 0
#     total_batch = int(mnist.train.num_examples / batch_size)
#
#     for i in range(total_batch):
#         batch_xs, batch_ys = mnist.train.next_batch(batch_size)
#         feed_dict = {X: batch_xs, Y: batch_ys}
#         c, _ = sess.run([cost, optimizer], feed_dict=feed_dict)
#         avg_cost += c / total_batch
#
#     print('Epoch:', '%04d' % (epoch + 1), 'cost =', '{:.9f}'.format(avg_cost))
#
# print('Learning Finished!')
#
# # Test model and check accuracy
# correct_prediction = tf.equal(tf.argmax(logits, 1), tf.argmax(Y, 1))
# accuracy = tf.reduce_mean(tf.cast(correct_prediction, tf.float32))
# print('Accuracy:', sess.run(accuracy, feed_dict={X: mnist.test.images, Y: mnist.test.labels}))

'''11/04/2020'''

#
# 'some dropout with stuff'
# # hyper parameters
# learning_rate = 0.001
# training_epochs = 20
# batch_size = 100
# class Model:
#     def __init__(self, sess, name):
#         self.sess = sess
#         self.name = name
#         self._build_net()
#     def _build_net(self):
#         with tf.variable_scope(self.name):
#             # dropout (keep_prob) rate  0.7~0.5 on training, but should be 1
#             # for testing
#             self.training = tf.placeholder(tf.bool)
#             # input place holders
#             self.X = tf.placeholder(tf.float32, [None, 784])
#             # img 28x28x1 (black/white), Input Layer
#             X_img = tf.reshape(self.X, [-1, 28, 28, 1])
#             self.Y = tf.placeholder(tf.float32, [None, 10])
#             # Convolutional Layer #1
#             conv1 = tf.layers.conv2d(inputs=X_img, filters=32, kernel_size=[3, 3],
#                                      padding="SAME", activation=tf.nn.relu)
#             # Pooling Layer #1
#             pool1 = tf.layers.max_pooling2d(inputs=conv1, pool_size=[2, 2],
#                                             padding="SAME", strides=2)
#             dropout1 = tf.layers.dropout(inputs=pool1,
#                                          rate=0.7, training=self.training)
#                                          #rate=0.3, training=self.training)
#
#             # Convolutional Layer #2 and Pooling Layer #2
#             conv2 = tf.layers.conv2d(inputs=dropout1, filters=64, kernel_size=[3, 3],
#                                      padding="SAME", activation=tf.nn.relu)
#             pool2 = tf.layers.max_pooling2d(inputs=conv2, pool_size=[2, 2],
#                                             padding="SAME", strides=2)
#             dropout2 = tf.layers.dropout(inputs=pool2,
#                                          rate=0.7, training=self.training)
#                                          #rate=0.3, training=self.training)
#
#             # Convolutional Layer #3 and Pooling Layer #3
#             conv3 = tf.layers.conv2d(inputs=dropout2, filters=128, kernel_size=[3, 3],
#                                      padding="SAME", activation=tf.nn.relu)
#             pool3 = tf.layers.max_pooling2d(inputs=conv3, pool_size=[2, 2],
#                                             padding="SAME", strides=2)
#             dropout3 = tf.layers.dropout(inputs=pool3,
#                                          rate=0.7, training=self.training)
#                                          #rate=0.3, training=self.training)
#
#             # Dense Layer with Relu
#             flat = tf.reshape(dropout3, [-1, 128 * 4 * 4])
#             dense4 = tf.layers.dense(inputs=flat,
#                                      units=625, activation=tf.nn.relu)
#             dropout4 = tf.layers.dropout(inputs=dense4,
#                                          rate=0.5, training=self.training)
#             # Logits (no activation) Layer: L5 Final FC 625 inputs -> 10 outputs
#             self.logits = tf.layers.dense(inputs=dropout4, units=10)
#         # define cost/loss & optimizer
#         self.cost = tf.reduce_mean(tf.nn.softmax_cross_entropy_with_logits(
#             logits=self.logits, labels=self.Y))
#         self.optimizer = tf.train.AdamOptimizer(
#             learning_rate=learning_rate).minimize(self.cost)
#         correct_prediction = tf.equal(
#             tf.argmax(self.logits, 1), tf.argmax(self.Y, 1))
#         self.accuracy = tf.reduce_mean(tf.cast(correct_prediction, tf.float32))
#     def predict(self, x_test, training=False):
#         return self.sess.run(self.logits,
#                              feed_dict={self.X: x_test, self.training: training})
#     def get_accuracy(self, x_test, y_test, training=False):
#         return self.sess.run(self.accuracy,
#                              feed_dict={self.X: x_test,
#                                         self.Y: y_test, self.training: training})
#     def train(self, x_data, y_data, training=True):
#         return self.sess.run([self.cost, self.optimizer], feed_dict={
#             self.X: x_data, self.Y: y_data, self.training: training})
# # initialize
# sess = tf.Session()
# models = []
# num_models = 2
# for m in range(num_models):
#     models.append(Model(sess, "model" + str(m)))
# sess.run(tf.global_variables_initializer())
# print('Learning Started!')
# # train my model
# for epoch in range(training_epochs):
#     avg_cost_list = np.zeros(len(models))
#     total_batch = int(mnist.train.num_examples / batch_size)
#     for i in range(total_batch):
#         batch_xs, batch_ys = mnist.train.next_batch(batch_size)
#         # train each model
#         for m_idx, m in enumerate(models):
#             c, _ = m.train(batch_xs, batch_ys)
#             avg_cost_list[m_idx] += c / total_batch
#     print('Epoch:', '%04d' % (epoch + 1), 'cost =', avg_cost_list)
# print('Learning Finished!')
# # Test model and check accuracy
# test_size = len(mnist.test.labels)
# predictions = np.zeros([test_size, 10])
# for m_idx, m in enumerate(models):
#     print(m_idx, 'Accuracy:', m.get_accuracy(
#         mnist.test.images, mnist.test.labels))
#     p = m.predict(mnist.test.images)
#     predictions += p
# ensemble_correct_prediction = tf.equal(
#     tf.argmax(predictions, 1), tf.argmax(mnist.test.labels, 1))
# ensemble_accuracy = tf.reduce_mean(
#     tf.cast(ensemble_correct_prediction, tf.float32))
# print('Ensemble accuracy:', sess.run(ensemble_accuracy))

'Deep CNN; take from her slides, similar to last lecture 18; also has dropout'
# learning_rate = 0.001
# training_epochs = 15
# batch_size = 100
# keep_prob = 0.7
#
# X = tf.placeholder(tf.float32, [None, 784])
# X_img = tf.reshape(X, [-1, 28, 28, 1]) # img 28x28x1 (black/white)
# Y = tf.placeholder(tf.float32, [None, 10])
# # L1 ImgIn shape=(?, 28, 28, 1)
# W1 = tf.Variable(tf.random_normal([3, 3, 1, 32], stddev=0.01))
# # Conv -> (?, 28, 28, 32)
# # Pool -> (?, 14, 14, 32)
# L1 = tf.nn.conv2d(X_img, W1, strides=[1, 1, 1, 1], padding='SAME')
# L1 = tf.nn.relu(L1)
# L1 = tf.nn.max_pool(L1, ksize=[1, 2, 2, 1],
# strides=[1, 2, 2, 1], padding='SAME')
# L1 = tf.nn.dropout(L1, keep_prob=keep_prob)
#
# W2 = tf.Variable(tf.random_normal([3, 3, 32, 64], stddev=0.01))
# # Conv ->(?, 14, 14, 64)
# # Pool ->(?, 7, 7, 64)
# L2 = tf.nn.conv2d(L1, W2, strides=[1, 1, 1, 1], padding='SAME')
# L2 = tf.nn.relu(L2)
# L2 = tf.nn.max_pool(L2, ksize=[1, 2, 2, 1],
# strides=[1, 2, 2, 1], padding='SAME')
# L2 = tf.nn.dropout(L2, keep_prob=keep_prob)
#
#
# W3 = tf.Variable(tf.random_normal([3, 3, 64, 128], stddev=0.01))
# # Conv ->(?, 7, 7, 128)
# # Pool ->(?, 4, 4, 128)
# # Reshape ->(?, 4 * 4 * 128) # Flatten them for FC
# L3 = tf.nn.conv2d(L2, W3, strides=[1, 1, 1, 1], padding='SAME')
# L3 = tf.nn.relu(L3)
# L3 = tf.nn.max_pool(L3, ksize=[1, 2, 2, 1], strides=[ 1, 2, 2, 1], padding='SAME')
# L3 = tf.nn.dropout(L3, keep_prob=keep_prob)
# L3_flat = tf.reshape(L3, [-1, 128 * 4 * 4])
#
# W4 = tf.get_variable("W4", shape=[128 * 4 * 4, 625],
# initializer=tf.contrib.layers.xavier_initializer())
# b4 = tf.Variable(tf.random_normal([625]))
# L4 = tf.nn.relu(tf.matmul(L3_flat, W4) + b4)
# L4 = tf.nn.dropout(L4, keep_prob=keep_prob)
#
# W5 = tf.get_variable("W5", shape=[625, 10],
# initializer=tf.contrib.layers.xavier_initializer())
# b5 = tf.Variable(tf.random_normal([10]))
# logits = tf.matmul(L4, W5) + b5
#
#
#
#
# # define cost/loss & optimizer
# cost = tf.reduce_mean(tf.nn.softmax_cross_entropy_with_logits(logits=logits, labels=Y))
# optimizer = tf.train.AdamOptimizer(learning_rate=learning_rate).minimize(cost)
#
# # initialize
# sess = tf.Session()
# sess.run(tf.global_variables_initializer())
# # train my model
# print('Learning started. It takes sometime.')
# for epoch in range(training_epochs):
#     avg_cost = 0
#     total_batch = int(mnist.train.num_examples / batch_size)
#     for i in range(total_batch):
#         batch_xs, batch_ys = mnist.train.next_batch(batch_size)
#         feed_dict = {X: batch_xs, Y: batch_ys, keep_prob: 0.7}
#         c, _ = sess.run([cost, optimizer], feed_dict=feed_dict)
#         avg_cost += c / total_batch
#     print('Epoch:', '%04d' % (epoch + 1), 'cost =', '{:.9f}'.format(avg_cost))
# print("Learning Finished!")
#
# # Test model and check accuracy
# correct_prediction = tf.equal(tf.argmax(logits, 1), tf.argmax(Y, 1))
# accuracy = tf.reduce_mean(tf.cast(correct_prediction, tf.float32))
# print('Accuracy:', sess.run(accuracy, feed_dict={X: mnist.test.images, Y: mnist.test.labels, keep_prob: 1}))
#
# r = random.randint(0, mnist.test.num_examples - 1)
# print("Label: ", sess.run(tf.argmax(mnist.test.labels[r:r + 1], 1)))
# print("Prediction: ", sess.run(tf.argmax(logits, 1), feed_dict={X: mnist.test.images[r:r + 1], keep_prob: 1}))
# plt.imshow(mnist.test.images[r:r + 1]. reshape(28, 28), cmap='Greys', interpolation='nearest')
# plt.show()


'''RNN, tim series, based on previous output
not possible in CNN or NN
conversation modeling


'''
# hidden_size = 2
# cell=tf.contrib.rnn.BasicRNNCell(num_units=hidden_size)
# x_data=np.array([[[1,0,0,0]]], dtype=np.float32)
# outputs, _states = tf.nn.dynamic_rnn(cell, x_data, dtype=tf.float32)
# sess.run(tf.global_variables_initializer())
# pp.pprint(outputs.eval())


'''11/09/2020
more RNN
example with 'hello'
    remove a duplicates that are ajacent to each other

input and output middle shape must match (first, middle, last)
    first is batch size = unique letters 
    middle is sequence length = letters -1
    last is hidden size


calc cost to see if model is good or not
    done by sequence_loss    
'''
# import statements
# import pprint as pp

'need to fix this one'
sess = tf.InteractiveSession()
# h = [1,0,0,0]
# e = [0,1,0,0]
# l = [0,0,1,0]
# o = [0,0,0,1]
# hidden_size = 2
# cell=tf.contrib.rnn.BasicRNNCell(num_units=hidden_size)
# x_data = np.array([[h,e,l,l,o]], dtype=np.float32)
# print(cell.output_size, cell.state_size)
# pp.pprint(x_data)
# outputs, _states = tf.nn.dynamic_rnn(cell, x_data, dtype=tf.float32)
# sess.run(tf.global_variables_initializer())
# pp.pprint(outputs.eval())


'another example after this one'

'how to make predictions'
# # run with interactive sessions
# y_data = tf.constant([[1,1,1]])
#
# prediction = tf.constant([[[0.2,0.7], [0.6,0.2], [0.2, 0.9]]], dtype=tf.float32)
# # the lower number is treated as a 0, and higher is 1; first position 1 means a 1, second means a zero
# weights = tf.constant([[1,1,1]], dtype=tf.float32)
# sequence_loss = tf.contrib.seq2seq.sequence_loss(prediction, targets = y_data, weights = weights)
#
# sess.run(tf.global_variables_initializer())
# print("Loss", sequence_loss.eval())


'actual example with hihello'

# idx2char = ['h', 'i', 'e', 'l', 'o']
# # Teach hello: hihell -> ihello
# x_data = [[0, 1, 0, 2, 3, 3]]   # hihell
# x_one_hot = [[[1, 0, 0, 0, 0],   # h 0
#               [0, 1, 0, 0, 0],   # i 1
#               [1, 0, 0, 0, 0],   # h 0
#               [0, 0, 1, 0, 0],   # e 2
#               [0, 0, 0, 1, 0],   # l 3
#               [0, 0, 0, 1, 0]]]  # l 3
#
# y_data = [[1, 0, 2, 3, 3, 4]]    # ihello
#
# num_classes = 5
# input_dim = 5  # one-hot size
# hidden_size = 5  # output from the LSTM. 5 to directly predict one-hot
# batch_size = 1   # one sentence
# sequence_length = 6  # |ihello| == 6
# learning_rate = 0.1
#
# X = tf.placeholder(tf.float32, [None, sequence_length, input_dim])  # X one-hot
# Y = tf.placeholder(tf.int32, [None, sequence_length])  # Y label
#
# cell = tf.contrib.rnn.BasicLSTMCell(num_units=hidden_size, state_is_tuple=True)
# initial_state = cell.zero_state(batch_size, tf.float32)
# outputs, _states = tf.nn.dynamic_rnn(cell, X, initial_state=initial_state, dtype=tf.float32)
#
# weights = tf.ones([batch_size, sequence_length])
# sequence_loss = tf.contrib.seq2seq.sequence_loss(logits=outputs, targets=Y, weights=weights)
# loss = tf.reduce_mean(sequence_loss)
# train = tf.train.AdamOptimizer(learning_rate=learning_rate).minimize(loss)
#
# prediction = tf.argmax(outputs, axis=2)
#
# with tf.Session() as sess:
#     sess.run(tf.global_variables_initializer())
#     for i in range(50):
#         l, _ = sess.run([loss, train], feed_dict={X: x_one_hot, Y: y_data})
#         result = sess.run(prediction, feed_dict={X: x_one_hot})
#         print(i, "loss:", l, "prediction: ", result, "true Y: ", y_data)
#
#         # print char using dic
#         result_str = [idx2char[c] for c in np.squeeze(result)]
#         print("\tPrediction str: ", ''.join(result_str))


'''11/11/2020
more examples with longer data
example of 'if you want'

uploaded on BB for our use

python creates the one hot encoding through indexes

In Debugger
    Add a BreakPoint
    run debugger
    click debug window, then console
    click the arrow below print in the console
    click on the python symbol
    Can set(sample) to see data
'''
'long sentences'

# sample = " if you want you"
# idx2char = list(set(sample))  # index -> char
# char2idx = {c: i for i, c in enumerate(idx2char)}  # char -> idex
#
# # hyper parameters
# dic_size = len(char2idx)  # RNN input size (one hot size)
# hidden_size = len(char2idx)  # RNN output size
# num_classes = len(char2idx)  # final output size (RNN or softmax, etc.)
# batch_size = 1  # one sample data, one batch
# sequence_length = len(sample) - 1  # number of lstm rollings (unit #)
# learning_rate = 0.1
#
# sample_idx = [char2idx[c] for c in sample]  # char to index
# x_data = [sample_idx[:-1]]  # X data sample (0 ~ n-1) hello: hell
# y_data = [sample_idx[1:]]   # Y label sample (1 ~ n) hello: ello
#
# X = tf.placeholder(tf.int32, [None, sequence_length])  # X data
# Y = tf.placeholder(tf.int32, [None, sequence_length])  # Y label
#
# x_one_hot = tf.one_hot(X, num_classes)  # one hot: 1 -> 0 1 0 0 0 0 0 0 0 0
# cell = tf.contrib.rnn.BasicLSTMCell(
#     num_units=hidden_size, state_is_tuple=True)
# initial_state = cell.zero_state(batch_size, tf.float32)
# outputs, _states = tf.nn.dynamic_rnn(cell, x_one_hot, initial_state=initial_state, dtype=tf.float32)
#
# weights = tf.ones([batch_size, sequence_length])
# sequence_loss = tf.contrib.seq2seq.sequence_loss(logits=outputs, targets=Y, weights=weights)
# loss = tf.reduce_mean(sequence_loss)
# train = tf.train.AdamOptimizer(learning_rate=learning_rate).minimize(loss)
#
# prediction = tf.argmax(outputs, axis=2)
#
# with tf.Session() as sess:
#     sess.run(tf.global_variables_initializer())
#     for i in range(50):
#         l, _ = sess.run([loss, train], feed_dict={X: x_data, Y: y_data})
#         result = sess.run(prediction, feed_dict={X: x_data})
#
#         # print char using dic
#         result_str = [idx2char[c] for c in np.squeeze(result)]
#
#         print(i, "loss:", l, "Prediction:", ''.join(result_str))


'really long sentences'
# # from __future__ import print_function #not all that needed??

# sentence = ("if you want to build a ship, don't drum up people together to "
#             "collect wood and don't assign them tasks and work, but rather "
#             "teach them to long for the endless immensity of the sea.")
#
# char_set = list(set(sentence))
# char_dic = {w: i for i, w in enumerate(char_set)}
#
# data_dim = len(char_set)
# hidden_size = len(char_set)
# num_classes = len(char_set)
# sequence_length = 10  # Any arbitrary number
# learning_rate = 0.1
#
# dataX = []
# dataY = []
# for i in range(0, len(sentence) - sequence_length):
#     x_str = sentence[i:i + sequence_length]
#     y_str = sentence[i + 1: i + sequence_length + 1]
#     print(i, x_str, '->', y_str)
#
#     x = [char_dic[c] for c in x_str]  # x str to index
#     y = [char_dic[c] for c in y_str]  # y str to index
#
#     dataX.append(x)
#     dataY.append(y)
#
# batch_size = len(dataX)
#
# X = tf.placeholder(tf.int32, [None, sequence_length])
# Y = tf.placeholder(tf.int32, [None, sequence_length])
#
# # One-hot encoding
# X_one_hot = tf.one_hot(X, num_classes)
# print(X_one_hot)  # check out the shape
#
# multi_cells = tf.contrib.rnn.BasicLSTMCell(num_units=hidden_size, state_is_tuple=True)
# # outputs: unfolding size x hidden size, state = hidden size
# outputs, _states = tf.nn.dynamic_rnn(multi_cells, X_one_hot, dtype=tf.float32)
#
# # All weights are 1 (equal weights)
# weights = tf.ones([batch_size, sequence_length])
#
# sequence_loss = tf.contrib.seq2seq.sequence_loss(logits=outputs, targets=Y, weights=weights)
# mean_loss = tf.reduce_mean(sequence_loss)
# train_op = tf.train.AdamOptimizer(learning_rate=learning_rate).minimize(mean_loss)
#
# sess = tf.Session()
# sess.run(tf.global_variables_initializer())
#
# for i in range(500):
#     _, l, results = sess.run([train_op, mean_loss, outputs], feed_dict={X: dataX, Y: dataY})
#     for j, result in enumerate(results):
#         index = np.argmax(result, axis=1)
#         tmp_x = ''.join([char_set[t] for t in dataX[j]])
#         tmp_p = ''.join([char_set[t] for t in index])
#         tmp_y = ''.join([char_set[t] for t in dataY[j]])
#         cmt = '[{}] Input=[{}], \tLabel=[{}], \tPrediction=[{}], \t Loss={}'.format(i, tmp_x, tmp_y, tmp_p, l)
#         print(cmt)
#
# # Let's print the last char of each result to check it works
# cmt = '\n\n [[ Trained Sentences ]]'
# print(cmt)
# results = sess.run(outputs, feed_dict={X: dataX})
# for j, result in enumerate(results):
#     index = np.argmax(result, axis=1)
#     if j is 0:  # print all for the first result to make a sentence
#         tmp = ''.join([char_set[t] for t in index])
#         cmt = '** The first batch j={} is [{}] **\n'.format(j, tmp)
#         print(cmt)
#         print(''.join([char_set[t] for t in index]), end='')
#     else:
#         print(char_set[index[-1]], end='')
#
# cmt = '----------------------------------------------------------'
# print(cmt)

'''NN can make it better
shape changes twice, once after RNN section and one after softmax
    batches, seq length, num of classes
first is reshapeoutputs
second is tf.contrib 

not sure if this is working or not
'''

# sentence = ("if you want to build a ship, don't drum up people together to "
#             "collect wood and don't assign them tasks and work, but rather "
#             "teach them to long for the endless immensity of the sea.")
#
# char_set = list(set(sentence))
# char_dic = {w: i for i, w in enumerate(char_set)}
#
# # hyper parameters
# data_dim = len(char_set)
# hidden_size = len(char_set)
# num_classes = len(char_set)
# sequence_length = 10  # Any arbitrary number
# learning_rate = 0.1
#
# dataX = [ ]
# dataY = [ ]
# for i in range ( 0, len(sentence ) - sequence_length ) :
#     x_str = sentence [ i : i + sequence_length ]
#     y_str = sentence [ i + 1 : i + sequence_length + 1 ]
#     # print ( i, x_str, ‘->’, y_str )
#     x = [ char_dic [ c ] for c in x_str ] # x str to index
#     y = [ char_dic [ c ] for c in x_str ] # y str to index
#     dataX.append ( x )
#     dataY.append ( y )
#
# batch_size = len ( dataX )
#
# X = tf.placeholder(tf.int32, [None, sequence_length])
# Y = tf.placeholder(tf.int32, [None, sequence_length])
#
# x_one_hot = tf.one_hot(X, num_classes)
# print(x_one_hot)
#
# cell = tf.contrib.rnn.BasicLSTMCell (num_units=hidden_size, state_is_tuple=True)
# cell = tf.contrib.rnn.MultiRNNCell ( [ cell ] * 2, state_is_tuple=True)
#
# initial_state = cell.zero_state(batch_size, tf.float32)
#
# outputs, _states = tf.nn.dynamic_rnn (cell, x_one_hot, initial_state=initial_state, dtype=tf.float32)
#
# x_for_fc = tf.reshape(outputs, [-1, hidden_size])
# outputs = tf.contrib.layers.fully_connected(x_for_fc, num_classes, activation_fn=None)
#
# outputs = tf. reshape ( outputs, [ batch_size, sequence_length, num_classes ] )
# # All weights are 1 (equal weights )
# weights = tf. ones ( [ batch_size, sequence_length ] )
#
# sequence_loss = tf.contrib.seq2seq.sequence_loss ( logits = outputs, targets = Y,
# weights = weights )
#
# mean_loss = tf.reduce_mean ( sequence_loss )
# train_op = tf.train.AdamOptimizer ( learning_rate = 0.1 ).minimize ( mean_loss )
#
#
# sess = tf.Session()
# sess.run(tf.global_variables_initializer())
# for i in range(500):
#     _, l, results = sess.run([train_op, mean_loss, outputs], feed_dict={X: dataX, Y: dataY})
#     for j, result in enumerate(results):
#         index = np.argmax(result, axis=1)
#         tmp_x = ''.join([char_set[t] for t in dataX[j]])
#         tmp_p = ''.join([char_set[t] for t in index])
#         tmp_y = ''.join([char_set[t] for t in dataY[j]])
#         cmt = '[{}] Input=[{}], \tLabel=[{}], \tPrediction=[{}], \t Loss={}'.format(i, tmp_x, tmp_y, tmp_p, l)
#         print(cmt)
#
# # Let's print the last char of each result to check it works
# cmt = '\n\n [[ Trained Sentences ]]'
# print(cmt)
# results = sess.run(outputs, feed_dict={X: dataX})
# for j, result in enumerate(results):
#     index = np.argmax(result, axis=1)
#     if j is 0:  # print all for the first result to make a sentence
#         tmp = ''.join([char_set[t] for t in index])
#         cmt = '** The first batch j={} is [{}] **\n'.format(j, tmp)
#         print(cmt)
#         print(''.join([char_set[t] for t in index]), end='')
#     else:
#         print(char_set[index[-1]], end='')
#
# cmt = '----------------------------------------------------------'
# print(cmt)


'''11/16/2020
More RNN

long sequence training is troublesome

LSTM = Long Short Term Memory
    adds the use of a memory cell
    use of sigmoids

Dynamic RNN
    allows for variable length of input data
        
'''

# pp = pp.PrettyPrinter(indent = 4)
# sess = tf.InteractiveSession()
#
# h = [1,0,0,0]
# e = [0,1,0,0]
# l = [0,0,1,0]
# o = [0,0,0,1]
#
# x_data = np.array([[h,e,l,l,o], [e,o,l,l,l], [l,l,e,e,l]], dtype=np.float32)
# pp.pprint(x_data)
#
# hidden_size = 2
# cell = tf.contrib.rnn.BasicLSTMCell(num_units=hidden_size, state_is_tuple=True)
# outputs, _states = tf.nn.dynamic_rnn(cell, x_data, sequence_length= [5,3,4], dtype=tf.float32)
# sess.run(tf.global_variables_initializer())
# print(outputs.eval())


'dynamic stock is an example for rnn'
#
# def MinMaxScaler(data):
#     numerator = data - np.min(data, 0)
#     denominator = np.max(data, 0) - np.min(data, 0)
#     # noise term prevents the zero division
#     return numerator / (denominator + 1e-7)
#
# #tf.reset_default_graph()
# # train Parameters
# seq_length = 7
# data_dim = 5
# hidden_dim = 10
# output_dim = 1
# learning_rate = 0.01
# iterations = 1000
#
# # Open, High, Low, Volume, Close
# data_path=r'C:\Users\Owner\Desktop\EKU\2020Fall\CSC546AI\Provided Notes\data04stockdaily.csv'
# xy = np.loadtxt(data_path, delimiter=',')
# xy = xy[::-1]  # reverse order (chronically ordered)
# x = xy
# y = xy[:,[-1]]
#
# # train/test split
# train_size = int(len(xy) * 0.7)
# train_set = xy[0:train_size]
# test_set = xy[train_size - seq_length:]  # Index from [train_size - seq_length] to utilize past sequence
#
# # Scale each
# train_set = MinMaxScaler(train_set)
# test_set = MinMaxScaler(test_set)
#
# # build datasets
# def build_dataset(time_series, seq_length):
#     dataX = []
#     dataY = []
#     for i in range(0, len(time_series) - seq_length):
#         _x = time_series[i:i + seq_length, :]
#         _y = time_series[i + seq_length, [-1]]  # Next close price
#         print(_x, "->", _y)
#         dataX.append(_x)
#         dataY.append(_y)
#     return np.array(dataX), np.array(dataY)
#
# trainX, trainY = build_dataset(train_set, seq_length)
# testX, testY = build_dataset(test_set, seq_length)
#
# # input place holders
# X = tf.placeholder(tf.float32, [None, seq_length, data_dim])
# Y = tf.placeholder(tf.float32, [None, 1])
#
# # build a LSTM network
# cell = tf.contrib.rnn.BasicLSTMCell(num_units=hidden_dim, state_is_tuple=True, activation=tf.tanh)
# outputs, _states = tf.nn.dynamic_rnn(cell, X, dtype=tf.float32)
# Y_pred = tf.contrib.layers.fully_connected(
#     outputs[:, -1], output_dim, activation_fn=None)  # We use the last cell's output
#
# # cost/loss
# loss = tf.reduce_sum(tf.square(Y_pred - Y))  # sum of the squares
# # optimizer
# optimizer = tf.train.AdamOptimizer(learning_rate)
# train = optimizer.minimize(loss)
#
# # RMSE
# targets = tf.placeholder(tf.float32, [None, 1])
# predictions = tf.placeholder(tf.float32, [None, 1])
# rmse = tf.sqrt(tf.reduce_mean(tf.square(targets - predictions)))
#
# with tf.Session() as sess:
#     init = tf.global_variables_initializer()
#     sess.run(init)
#
#     # Training step
#     for i in range(iterations):
#         _, step_loss = sess.run([train, loss], feed_dict={X: trainX, Y: trainY})
#         print("[step: {}] loss: {}".format(i, step_loss))
#
#     # Test step
#     test_predict = sess.run(Y_pred, feed_dict={X: testX})
#     rmse_val = sess.run(rmse, feed_dict={targets: testY, predictions: test_predict})
#     print("RMSE: {}".format(rmse_val))
#
#     # Plot predictions
#     plt.plot(testY, 'r')
#     plt.plot(test_predict, 'b')
#     plt.xlabel("Time Period")
#     plt.ylabel("Stock Price")
#     plt.show()


'''11/23/2020
New teacher

a kernal = feature = filter
    example: edges -> texture -> object part -> referenced object

Transfer Learning
    model trainted on one task, can be used to improve generalization of another model
    CIFAR, example with training
   
Ensemble Learning
    train multiple models, then combine them
    
    EXAMPLE
        *(not strictly ensemble)
        mammogram, 2D and 3D(video slices) comparison
        separate freature maps for 2d and 3d
        then concatenate
        classify on cat

AUC - area under curve
    better than accuracy for weighted predicion
    takes into consideration amounts and such
    Imagine 1 covid and 9 normal
        if guess all normal, accuracy is 90
            AUC is .5
     
    
Random forest 
    multiple decision trees and the result of those trees help decide the ending result
    
Weakly Supervised training
    better for smaller data sets
    INEXACT
        
    IN
   
CAM - Class Activation Mapping
    way to visualize classification model decision makings
    often done by heatmap
    higher work when getting closer to desired object
    
    STEPS
        get all weights for fully connected(FC) layer
            n maps -> n weights
        weighted sum of n features maps from last conv-layer.
        
 
pytorch is another thing like tensorflow
'''

'''11/25/2020
Last Day of Class

MIA= Min Absolute Error

InExact Supervised Learning
    
Cross -Domain Weakly supervised Learning
    
GAN = Generative Adversarial Network
    helps for generation? mulic, images, words
    generate does possible data
    discriminator = makes decision of real or fake

cGAN = conditional GAN
    generate occording to condition
    must have a source and a target to train cGAN
    
Cycle GAN = does not need a target
    deepfakes
    
 
     

FINAL EXAM NOTES
    Thursday Dec 3  3:30-4:30
    email questions and answers
    RNN, LSTM, Dynamic RNN, RNN with time series (stock data) 
    
'''