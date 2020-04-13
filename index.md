# Zoo Management System

Hello Everyone,

My name is Ramy Tawfik, this is my ePortfolio to show my work for my CS-499 Computer Science Capstone, My final class of my Computer Science Degree, at Southern New Hampshire University. 

I have learned many important concepts and skills in the Computer Science program. In my CS-250 I learned about the software development life cycle “ Agile and waterfall”. Agile methodology was a new concept for me, and I learned a lot of important information about it and how to use Agile methodology while developing a software product. I also learned about object-oriented programing concepts and gained important skills when I develop software using different programming languages. I also learned C++ in my IT-312  Software Devel w/C++.Net class and made a final project using C++[LCR-Game](https://github.com/ramy-tawfik/Study-LCR-Game-C-), Java in my IT-145 Found. in App Development class. In CS-320 Q1397 Software Test, Automation& QA Class I learned a lot of skills in software testing and how important to test my software application. I also learned other skills that I will use such as problem-solving skills and critical thinking skills. CS-260 Data Structures and Algorithms class taught me a lot of important concepts in the data structure and algorithms and how too choose the write thing upon the situation. These are a few examples of what I have learned over the last years during my education journey at SNHU.


Completing my Computer Science degree at SNHU gave me a lot of experience and skills that I will need in my future career as a Software developer. Not just gave me knowledge but taught me how to continually learn and seek new skills and challenges.
During my learning journey at SNHU, I’ve learned C++, Java, and Python. So, for my Final Project, I choose to do it using a new programming language C# because this will give me a chance to learn C# and learn new skills and face new challenges. I will use C# and Windows Forms to develop my project and also to learn new skills.



## Selected artifact
I will be working on the final project for IT-145 which I developed using Java more than a year ago. The project was developing a console application as an authentication system for a Zoo

## Existing functionality

The application was required to follow this scenario 

1. Ask a user for a username.
2. Ask a user for a password.
3. Convert the password using a message digest five (MD5) hash.
4. Check the credentials against the valid credentials provided in the file (use the hashed passwords in the second column; the third       column contains the actual passwords for testing).
5. Limit failed attempts to three before notifying the user and exiting.
6. After successful authentication, uses the role in the credential file to display the correct system information loaded from the          specific role file. 
7. Allow a user to log out.
8. Stays on the credential screen until either a successful attempt has been made, three unsuccessful attempts have been made, or a        user chooses to exit.
## Code Review
<iframe width="560" height="315" src="https://www.youtube.com/embed/3UwCrfv-Kws" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>

<iframe width="560" height="315" src="https://www.youtube.com/embed/StZZ_uEZfIk" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>

### Enhancement
My enhancement for the selected project will be three key categories
- Software design and engineering
- Algorithms and data structure
- Databases 

### Software design and engineering
1. Redesigned the project and changed the programing language to C#. 
2. Use Windows Forms to develop the application.
2. Designed Login Form, Admin Form, and Zookeeper Form using windows forms.
3. Expanded the application complexity and functionality.
4. Added Admin Functionality [Admin Form](admin.PNG)
    - View users
    - View total user count.
    - Add user functionality.
    - Added update user functionality. [Update user Form](update user.PNG)

5. Added Zookeeper Functionality [ZooKeeper Form](zookeeper.PNG)
    - view animals by Class, Status, and Species.
    - update animal info.
    - search/view animals.
    - Search animal by Class / Species / Name / Status. [Search Form](zookeeper search.PNG)
    - Add animal. [Add Animal](add animals.PNG) 
6. Converted the password using a message digest five (MD5) hash. Enhance security.


### Algorithms and data structure
Used object-oriented programming concepts to design and developed this application I  also used algorithms and data structures skills to create a more organized and deficient application.

```
    public enum UserRole
    {
        Admin,
        ZooKeeper
    }

```
```
public class User
    {
        private int ID;
        private string firstName;
        private string lastName;
        private string username;
        private userRole role;

        public int userID { get => ID; set => ID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public userRole Role { get => role; set => role = value; }
        public string Username { get => username; set => username = value; }

        public string DisplayName()
        {
            return this.firstName + " " + this.lastName;
        }
    }
```
```
    public enum AnimalClass
    {
        Amphibian,
        Bird,
        Mammal,
        Reptile
    }
```   
```
    public class Animal
    {
        private int ID;
        private AnimalClass animalClass;
        private string animalName;
        private string species;
        private string gender;
        private AnimalStatus status;
        private DateTime lastFeed;

        public int AnimalID { get => ID; set => ID = value; }
        public string AnimalName { get => animalName; set => animalName = value; }
        public string Species { get => species; set => species = value; }
        public AnimalStatus Status { get => status; set => status = value; }
        public DateTime LastFeed { get => lastFeed; set => lastFeed = value; }
        public AnimalClass AnimalClass { get => animalClass; set => animalClass = value; }
        public string Gender { get => gender; set => gender = value; }

        public override string ToString()
        {
            string animalSt;

            animalSt = String.Format("{0,-25}: {1}\t\n{2,-25}: {3}\t\n{4,-25}: {5}\t\n{6,-25}: {7}\t\n{8,-25}: {9}\t\n{10,-25}:   {11}\t\n",
                        "Animal Name", animalName,
                        "Animal Class", animalClass.ToString(),
                        "Animal Species", species.ToString(),
                        "Animal Status", status.ToString(),
                        "Animal Gender", gender,
                        "Last Feed", lastFeed.ToString());

            return animalSt;
        }
    }
```

I also Used Lists to store data retrieved from the SQL database.
```
        //Array List to save animals data
        ArrayList animalList = new ArrayList();
        // ArrayList to save Users list retrieved from the Database
        private ArrayList userList = new ArrayList();
        
```
Implemented Search features to Admin and Zookeeper forms to search animals by Class, Species, Status, and name. Looking at The number of records for animals and users I see that no advanced search algorithms are needed so I only implemented a linear search but in different situations, we will need different search algorithms such as binary search.
```
foreach (Animal item in animalList)
```

### Databases 

The original application was developed to save data into a text file and that is not secure and not practical. The enhancement of the database category was essential.

1. Created a remote MySQL database.
2. Hosted the MySQL database remotely on a hosting server to be accessible from anywhere
2. Designed user's and animals’ tables and columns.
3. Populated the animal’s table with data " Class,Species,Status" retrieved from the Philadelphia zoo website. 
4. Used SQL parameters to pass values to SQL queries to avoid SQL injection.
5. Created search, update, add features to Admin and Zookeeper forms.





### Markdown




Markdown is a lightweight and easy-to-use syntax for styling your writing. It includes conventions for

```markdown
Syntax highlighted code block

# Header 1
## Header 2
### Header 3

- Bulleted
- List

1. Numbered
2. List

**Bold** and _Italic_ and `Code` text

[Link](url) and ![Image](src)
```

For more details see [GitHub Flavored Markdown](https://guides.github.com/features/mastering-markdown/).

### Jekyll Themes

Your Pages site will use the layout and styles from the Jekyll theme you have selected in your [repository settings](https://github.com/ramy-tawfik/ramy-tawfik.github.io/settings). The name of this theme is saved in the Jekyll `_config.yml` configuration file.

### Support or Contact

Having trouble with Pages? Check out our [documentation](https://help.github.com/categories/github-pages-basics/) or [contact support](https://github.com/contact) and we’ll help you sort it out.
