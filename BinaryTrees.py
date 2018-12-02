import queue as q
class BinarySearchTree:
    def __init__(self,value):
        self.value = value
        self.left_child = None
        self.right_child = None

    def insert(self,value):
        if value <= self.value and self.left_child:
            self.left_child.insert(value)
        elif value <= self.value:
            self.left_child = BinarySearchTree(value)
        elif value > self.value and self.right_child:
            self.right_child.insert(value)
        else:
            self.right_child = BinarySearchTree(value)

    def search(self,value):
        if value < self.value and self.left_child:
            return self.left_child.search(value)
        if value > self.value and self.right_child:
            return self.right_child.search(value)
            
        return value == self.value

class BinaryTree:
    ''' Tree Traversal Sample methods '''
    def __init__(self,value):
        self.value = value
        self.left_child = None
        self.right_child = None

    def insert(self,value):
        ''' Insert method for maintaining an ordered binary tree
         unnecessarily using left and right insert methods '''
        if self.value > value:
            if self.right_child:
                self.right_child.insert_ordered(value)
            else:
                self.insert_right
        elif self.value <= value:
            if self.left_child:
                self.left_child.insert_ordered(value)
            else:
                self.insert_left

    def insert_left(self,value):
        if self.left_child == None:
            self.left_child = BinaryTree(value)
        else:
            new_node = BinaryTree(value)
            new_node.left_child = self.left_child
            self.left_child = new_node
    def insert_right(self, value):
        if self.right_child == None:
            self.right_child = BinaryTree(value)
        else:
            new_node = BinaryTree(value)
            new_node.right_child = self.right_child
            self.right_child = new_node
#Depth first tree traversal methods that print the values
    def pre_order(self):
        '''The middle first, the left second, and the right last'''
        print(self.value)
        if self.left_child:
            self.left_child.pre_order()
        if self.right_child:
            self.right_child.pre_order()

    def in_order(self):
        '''The left first, the middle second, and the right last'''
        if self.left_child:
            self.left_child.in_order()
        
        print(self.value)

        if self.right_child:
            self.right_child.in_order()
    
    def post_order(self): 
        '''The left first, the right second, and the middle last'''
        if self.left_child:
            self.left_child.post_order()

        if self.right_child:
             self.right_child.post_order()

        print(self.value)

    def breadth_first(self):
        queue = q.Queue()
        queue.put(self)

        while not queue.empty():
            current_node = queue.get()
            print(current_node.value)

            if current_node.left_child:
                queue.put(current_node.left_child)
            if current_node.right_child:
                queue.put(current_node.right_child)

    

        
#1
a_node = BinaryTree('1')
a_node.insert_left('2')
a_node.insert_right('5')
#2
b_node = a_node.left_child
b_node.insert_left('3')
b_node.insert_right('4')
#3
d_node = b_node.left_child
#4
g_node = b_node.right_child
#5
c_node = a_node.right_child
c_node.insert_left('6')
c_node.insert_right('7')
#6
e_node = c_node.left_child
#7
f_node = c_node.right_child



a_node.in_order()
print(" ")
a_node.pre_order()
print(" ")
a_node.breadth_first()



newTree = BinarySearchTree(10)

newTree.insert(1)
newTree.insert(12)
newTree.insert(21)
newTree.insert(14)
newTree.insert(15)
newTree.insert(15)
newTree.insert(16)
newTree.insert(19)
newTree.insert(441)
newTree.insert(111)
newTree.insert(13)

print(newTree.search(1))
print(newTree.search(15))
print(newTree.search(441))
print(newTree.search(3))
