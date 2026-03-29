using Microsoft.EntityFrameworkCore;
using OnlineEnrollmentMVC.Models;

namespace OnlineEnrollmentMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUser>().HasData(
                new AdminUser { Id = 1, FullName = "Administrator", Email = "admin@onlineenrollment.com", Password = "admin123" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Code = "BSA", Name = "BS Accountancy", Department = "Business", Schedule = "MWF 7:30-9:00", Units = 24, Slots = 40 },
                new Course { Id = 2, Code = "BSBA", Name = "BS Business Administration", Department = "Business", Schedule = "TTH 7:30-9:00", Units = 24, Slots = 40 },
                new Course { Id = 3, Code = "BSE", Name = "BS Entrepreneurship", Department = "Business", Schedule = "MWF 9:00-10:30", Units = 24, Slots = 40 },
                new Course { Id = 4, Code = "BSME", Name = "BS Management Engineering", Department = "Business", Schedule = "TTH 9:00-10:30", Units = 24, Slots = 40 },
                new Course { Id = 5, Code = "BSCS", Name = "BS Computer Science", Department = "STEM", Schedule = "MWF 7:30-9:00", Units = 24, Slots = 40 },
                new Course { Id = 6, Code = "BSIT", Name = "BS Information Technology", Department = "STEM", Schedule = "TTH 7:30-9:00", Units = 24, Slots = 40 },
                new Course { Id = 7, Code = "BSCE", Name = "BS Civil Engineering", Department = "STEM", Schedule = "MWF 9:00-10:30", Units = 24, Slots = 40 },
                new Course { Id = 8, Code = "BSEE", Name = "BS Electrical Engineering", Department = "STEM", Schedule = "TTH 9:00-10:30", Units = 24, Slots = 40 },
                new Course { Id = 9, Code = "BSBIO", Name = "BS Biology", Department = "STEM", Schedule = "MWF 10:30-12:00", Units = 24, Slots = 40 },
                new Course { Id = 10, Code = "BSN", Name = "BS Nursing", Department = "STEM", Schedule = "TTH 10:30-12:00", Units = 24, Slots = 40 },
                new Course { Id = 11, Code = "BSPSY", Name = "BS Psychology", Department = "Social Sciences", Schedule = "MWF 7:30-9:00", Units = 24, Slots = 40 },
                new Course { Id = 12, Code = "ABCOM", Name = "AB Communication", Department = "Social Sciences", Schedule = "TTH 7:30-9:00", Units = 24, Slots = 40 },
                new Course { Id = 13, Code = "ABPOLSCI", Name = "AB Political Science", Department = "Social Sciences", Schedule = "MWF 9:00-10:30", Units = 24, Slots = 40 },
                new Course { Id = 14, Code = "ABFA", Name = "AB Fine Arts", Department = "Social Sciences", Schedule = "TTH 9:00-10:30", Units = 24, Slots = 40 },
                new Course { Id = 15, Code = "BSED", Name = "BS Secondary Education", Department = "Education", Schedule = "MWF 7:30-9:00", Units = 24, Slots = 40 },
                new Course { Id = 16, Code = "BEED", Name = "BS Elementary Education", Department = "Education", Schedule = "TTH 7:30-9:00", Units = 24, Slots = 40 },
                new Course { Id = 17, Code = "BSARCH", Name = "BS Architecture", Department = "Education", Schedule = "MWF 9:00-10:30", Units = 24, Slots = 40 },
                new Course { Id = 18, Code = "MMA", Name = "Multimedia Arts", Department = "Education", Schedule = "TTH 9:00-10:30", Units = 24, Slots = 40 },
                new Course { Id = 19, Code = "HRM", Name = "Hotel & Restaurant Management", Department = "General Education", Schedule = "MWF 7:30-9:00", Units = 24, Slots = 40 },
                new Course { Id = 20, Code = "BSLM", Name = "BS Legal Management", Department = "General Education", Schedule = "TTH 7:30-9:00", Units = 24, Slots = 40 }
            );

            // MINOR SUBJECTS
            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "English Communication 1", Type = "Minor", Units = 3, YearLevel = 1, Semester = 1, CourseId = null },
                new Subject { Id = 2, Name = "Mathematics in the Modern World", Type = "Minor", Units = 3, YearLevel = 1, Semester = 1, CourseId = null },
                new Subject { Id = 3, Name = "Filipino 1", Type = "Minor", Units = 3, YearLevel = 1, Semester = 1, CourseId = null },
                new Subject { Id = 4, Name = "Life and Works of Rizal", Type = "Minor", Units = 3, YearLevel = 1, Semester = 1, CourseId = null },
                new Subject { Id = 5, Name = "English Communication 2", Type = "Minor", Units = 3, YearLevel = 1, Semester = 2, CourseId = null },
                new Subject { Id = 6, Name = "Filipino 2", Type = "Minor", Units = 3, YearLevel = 1, Semester = 2, CourseId = null },
                new Subject { Id = 7, Name = "Physical Education 1", Type = "Minor", Units = 3, YearLevel = 1, Semester = 2, CourseId = null },
                new Subject { Id = 8, Name = "National Service Training 1", Type = "Minor", Units = 3, YearLevel = 1, Semester = 2, CourseId = null },
                new Subject { Id = 9, Name = "Ethics and Moral Philosophy", Type = "Minor", Units = 3, YearLevel = 2, Semester = 1, CourseId = null },
                new Subject { Id = 10, Name = "Social Science 1", Type = "Minor", Units = 3, YearLevel = 2, Semester = 1, CourseId = null },
                new Subject { Id = 11, Name = "Physical Education 2", Type = "Minor", Units = 3, YearLevel = 2, Semester = 1, CourseId = null },
                new Subject { Id = 12, Name = "National Service Training 2", Type = "Minor", Units = 3, YearLevel = 2, Semester = 1, CourseId = null },
                new Subject { Id = 13, Name = "Philippine History", Type = "Minor", Units = 3, YearLevel = 2, Semester = 2, CourseId = null },
                new Subject { Id = 14, Name = "Social Science 2", Type = "Minor", Units = 3, YearLevel = 2, Semester = 2, CourseId = null },
                new Subject { Id = 15, Name = "Physical Education 3", Type = "Minor", Units = 3, YearLevel = 2, Semester = 2, CourseId = null },
                new Subject { Id = 16, Name = "Art Appreciation", Type = "Minor", Units = 3, YearLevel = 2, Semester = 2, CourseId = null },
                new Subject { Id = 17, Name = "Environmental Science", Type = "Minor", Units = 3, YearLevel = 3, Semester = 1, CourseId = null },
                new Subject { Id = 18, Name = "The Contemporary World", Type = "Minor", Units = 3, YearLevel = 3, Semester = 1, CourseId = null },
                new Subject { Id = 19, Name = "Physical Education 4", Type = "Minor", Units = 3, YearLevel = 3, Semester = 1, CourseId = null },
                new Subject { Id = 20, Name = "Gender and Society", Type = "Minor", Units = 3, YearLevel = 3, Semester = 1, CourseId = null },
                new Subject { Id = 21, Name = "Science Technology and Society", Type = "Minor", Units = 3, YearLevel = 3, Semester = 2, CourseId = null },
                new Subject { Id = 22, Name = "Understanding the Self", Type = "Minor", Units = 3, YearLevel = 3, Semester = 2, CourseId = null },
                new Subject { Id = 23, Name = "Readings in Philippine History", Type = "Minor", Units = 3, YearLevel = 3, Semester = 2, CourseId = null },
                new Subject { Id = 24, Name = "Purposive Communication", Type = "Minor", Units = 3, YearLevel = 3, Semester = 2, CourseId = null },
                new Subject { Id = 25, Name = "The Entrepreneurial Mind", Type = "Minor", Units = 3, YearLevel = 4, Semester = 1, CourseId = null },
                new Subject { Id = 26, Name = "People and the Earth Ecosystem", Type = "Minor", Units = 3, YearLevel = 4, Semester = 1, CourseId = null },
                new Subject { Id = 27, Name = "Panitikang Panlipunan", Type = "Minor", Units = 3, YearLevel = 4, Semester = 1, CourseId = null },
                new Subject { Id = 28, Name = "Kontekstwalisasyon ng Wikang Filipino", Type = "Minor", Units = 3, YearLevel = 4, Semester = 1, CourseId = null },
                new Subject { Id = 29, Name = "Intro to Research", Type = "Minor", Units = 3, YearLevel = 4, Semester = 2, CourseId = null },
                new Subject { Id = 30, Name = "Community Engagement", Type = "Minor", Units = 3, YearLevel = 4, Semester = 2, CourseId = null },
                new Subject { Id = 31, Name = "Internship Seminar", Type = "Minor", Units = 3, YearLevel = 4, Semester = 2, CourseId = null },
                new Subject { Id = 32, Name = "Values Education", Type = "Minor", Units = 3, YearLevel = 4, Semester = 2, CourseId = null }
            );

            // MAJOR SUBJECTS
            int sid = 33;
            var allMajors = new Dictionary<int, string[]>
            {
                [1] = new[] {
                    "Financial Accounting 1","Management Accounting 1","Business Law 1","Economics 1",
                    "Financial Accounting 2","Management Accounting 2","Business Law 2","Economics 2",
                    "Intermediate Accounting 1","Cost Accounting 1","Auditing Theory 1","Taxation 1",
                    "Intermediate Accounting 2","Cost Accounting 2","Auditing Theory 2","Taxation 2",
                    "Advanced Accounting 1","Auditing Practice 1","Business Finance 1","CPA Review 1",
                    "Advanced Accounting 2","Auditing Practice 2","Business Finance 2","CPA Review 2",
                    "Accounting Research 1","Accounting Systems","Government Accounting","Accounting Elective 1",
                    "Accounting Research 2","Accounting Capstone 1","Accounting Capstone 2","Accounting Elective 2"
                },
                [2] = new[] {
                    "Principles of Management","Business Communication 1","Microeconomics","Business Math 1",
                    "Business Communication 2","Organizational Behavior","Macroeconomics","Business Math 2",
                    "Human Resource Management","Marketing Management 1","Operations Management 1","Business Finance 1",
                    "Marketing Management 2","Operations Management 2","Business Finance 2","Business Law",
                    "Strategic Management 1","Entrepreneurship 1","International Business 1","Business Research 1",
                    "Strategic Management 2","Entrepreneurship 2","International Business 2","Business Research 2",
                    "Business Ethics","Supply Chain Management","Business Policy 1","BA Elective 1",
                    "Business Capstone 1","Business Capstone 2","Business Policy 2","BA Elective 2"
                },
                [3] = new[] {
                    "Intro to Entrepreneurship","Business Planning 1","Market Research 1","Innovation Management 1",
                    "Business Planning 2","Market Research 2","Innovation Management 2","Product Development 1",
                    "Venture Capital 1","Social Entrepreneurship 1","Business Model Design 1","Digital Marketing 1",
                    "Venture Capital 2","Social Entrepreneurship 2","Business Model Design 2","Digital Marketing 2",
                    "Startup Management 1","Supply Chain Management","Financial Planning 1","Entrepreneurship Research 1",
                    "Startup Management 2","Product Development 2","Financial Planning 2","Entrepreneurship Research 2",
                    "Business Scaling 1","Legal Aspects of Business","E-Commerce","Entrepreneurship Elective 1",
                    "Business Scaling 2","Entrepreneurship Capstone 1","Entrepreneurship Capstone 2","Entrepreneurship Elective 2"
                },
                [4] = new[] {
                    "Engineering Math 1","Engineering Drawing 1","Physics for Engineers 1","Chemistry for Engineers",
                    "Engineering Math 2","Engineering Drawing 2","Physics for Engineers 2","Statics of Rigid Bodies",
                    "Dynamics","Thermodynamics 1","Industrial Engineering 1","Operations Research 1",
                    "Thermodynamics 2","Industrial Engineering 2","Operations Research 2","Quality Management 1",
                    "Project Management 1","Systems Engineering 1","Engineering Economics 1","ME Research 1",
                    "Project Management 2","Systems Engineering 2","Engineering Economics 2","ME Research 2",
                    "Engineering Management 1","Safety Engineering","Production Planning","ME Elective 1",
                    "Engineering Management 2","ME Capstone 1","ME Capstone 2","ME Elective 2"
                },
                [5] = new[] {
                    "Intro to Programming","Discrete Mathematics 1","Computer Organization 1","Data Structures 1",
                    "Object Oriented Programming","Discrete Mathematics 2","Computer Organization 2","Data Structures 2",
                    "Algorithm Design 1","Operating Systems 1","Database Systems 1","Software Engineering 1",
                    "Algorithm Design 2","Operating Systems 2","Database Systems 2","Software Engineering 2",
                    "Computer Networks 1","Artificial Intelligence 1","Machine Learning 1","CS Research 1",
                    "Computer Networks 2","Artificial Intelligence 2","Machine Learning 2","CS Research 2",
                    "Information Security 1","Distributed Systems","Compiler Design","CS Elective 1",
                    "Information Security 2","CS Capstone 1","CS Capstone 2","CS Elective 2"
                },
                [6] = new[] {
                    "Intro to IT","Web Development 1","Computer Fundamentals","IT Mathematics 1",
                    "Web Development 2","IT Mathematics 2","Database Management 1","Network Fundamentals 1",
                    "Systems Analysis 1","Database Management 2","Network Fundamentals 2","IT Project Management 1",
                    "Systems Analysis 2","Mobile Development 1","IT Project Management 2","Cloud Computing 1",
                    "Mobile Development 2","Cloud Computing 2","Systems Integration 1","IT Research 1",
                    "Systems Integration 2","IT Security 1","IT Research 2","IT Elective 1",
                    "IT Security 2","IT Elective 2","IT Elective 3","IT Capstone 1",
                    "IT Elective 4","IT Capstone 2","IT Capstone 3","IT Capstone 4"
                },
                [7] = new[] {
                    "Engineering Math 1","Engineering Drawing 1","Surveying 1","Statics 1",
                    "Engineering Math 2","Engineering Drawing 2","Surveying 2","Statics 2",
                    "Strength of Materials 1","Fluid Mechanics 1","Structural Analysis 1","Geotechnical Engineering 1",
                    "Strength of Materials 2","Fluid Mechanics 2","Structural Analysis 2","Geotechnical Engineering 2",
                    "Highway Engineering 1","Construction Management 1","Structural Design 1","CE Research 1",
                    "Highway Engineering 2","Construction Management 2","Structural Design 2","CE Research 2",
                    "Environmental Engineering 1","Water Resources Engineering","Transportation Engineering","CE Elective 1",
                    "Environmental Engineering 2","CE Capstone 1","CE Capstone 2","CE Elective 2"
                },
                [8] = new[] {
                    "Circuit Theory 1","Engineering Math 1","Physics for EE 1","Engineering Drawing",
                    "Circuit Theory 2","Engineering Math 2","Physics for EE 2","Electronics 1",
                    "Electronics 2","Electromagnetics 1","Electrical Machines 1","Power Systems 1",
                    "Electromagnetics 2","Electrical Machines 2","Power Systems 2","Control Systems 1",
                    "Control Systems 2","Instrumentation 1","EE Research 1","EE Elective 1",
                    "Instrumentation 2","Power Electronics","EE Research 2","EE Elective 2",
                    "High Voltage Engineering","Renewable Energy Systems","EE Elective 3","EE Capstone 1",
                    "EE Elective 4","EE Capstone 2","EE Capstone 3","EE Capstone 4"
                },
                [9] = new[] {
                    "General Biology 1","General Chemistry 1","Cell Biology 1","Botany 1",
                    "General Biology 2","General Chemistry 2","Cell Biology 2","Botany 2",
                    "Genetics 1","Zoology 1","Ecology 1","Microbiology 1",
                    "Genetics 2","Zoology 2","Ecology 2","Microbiology 2",
                    "Biochemistry 1","Evolution 1","Molecular Biology 1","Biology Research 1",
                    "Biochemistry 2","Evolution 2","Molecular Biology 2","Biology Research 2",
                    "Biostatistics","Developmental Biology","Immunology","Biology Elective 1",
                    "Bioinformatics","Biology Capstone 1","Biology Capstone 2","Biology Elective 2"
                },
                [10] = new[] {
                    "Anatomy and Physiology 1","Fundamentals of Nursing 1","Health Assessment 1","Nutrition 1",
                    "Anatomy and Physiology 2","Fundamentals of Nursing 2","Health Assessment 2","Nutrition 2",
                    "Medical Surgical Nursing 1","Pharmacology 1","Microbiology for Nurses","Maternal Nursing 1",
                    "Medical Surgical Nursing 2","Pharmacology 2","Child Nursing","Maternal Nursing 2",
                    "Psychiatric Nursing 1","Community Health Nursing 1","Critical Care Nursing 1","Nursing Research 1",
                    "Psychiatric Nursing 2","Community Health Nursing 2","Critical Care Nursing 2","Nursing Research 2",
                    "Nursing Leadership 1","Gerontological Nursing","Perioperative Nursing","Nursing Elective 1",
                    "Nursing Leadership 2","Nursing Review 1","Nursing Review 2","Nursing Elective 2"
                },
                [11] = new[] {
                    "Intro to Psychology","Developmental Psychology 1","Biological Psychology 1","Research Methods 1",
                    "Developmental Psychology 2","Biological Psychology 2","Social Psychology 1","Research Methods 2",
                    "Social Psychology 2","Cognitive Psychology 1","Abnormal Psychology 1","Psychological Testing 1",
                    "Cognitive Psychology 2","Abnormal Psychology 2","Psychological Testing 2","Counseling Psychology 1",
                    "Counseling Psychology 2","Industrial Psychology 1","Health Psychology 1","Psychology Research 1",
                    "Industrial Psychology 2","Health Psychology 2","Neuropsychology 1","Psychology Research 2",
                    "Neuropsychology 2","Forensic Psychology","Psychology Elective 1","Psychology Capstone 1",
                    "Clinical Psychology","Psychology Elective 2","Psychology Capstone 2","Psychology Capstone 3"
                },
                [12] = new[] {
                    "Intro to Communication","Writing for Media 1","Speech Communication 1","Media Studies 1",
                    "Writing for Media 2","Speech Communication 2","Media Studies 2","Broadcast Journalism 1",
                    "Broadcast Journalism 2","Public Relations 1","Advertising 1","Communication Research 1",
                    "Public Relations 2","Advertising 2","Communication Research 2","Digital Media 1",
                    "Digital Media 2","Film and TV Production 1","Corporate Communication 1","Comm Research 3",
                    "Film and TV Production 2","Corporate Communication 2","Communication Ethics","Comm Research 4",
                    "Media Management","Communication Law","Communication Elective 1","Comm Capstone 1",
                    "Communication Elective 2","Comm Capstone 2","Comm Capstone 3","Comm Capstone 4"
                },
                [13] = new[] {
                    "Intro to Political Science","Philippine Government 1","Political Theory 1","International Relations 1",
                    "Philippine Government 2","Political Theory 2","International Relations 2","Comparative Politics 1",
                    "Comparative Politics 2","Public Administration 1","Political Economy 1","Public Policy 1",
                    "Public Administration 2","Political Economy 2","Public Policy 2","Constitutional Law 1",
                    "Constitutional Law 2","Political Research 1","Local Government","PolSci Elective 1",
                    "Political Research 2","International Law","Electoral Studies","PolSci Elective 2",
                    "Diplomatic Studies","Human Rights Law","PolSci Elective 3","PolSci Capstone 1",
                    "Peace and Conflict Studies","PolSci Elective 4","PolSci Capstone 2","PolSci Capstone 3"
                },
                [14] = new[] {
                    "Drawing 1","Color Theory 1","Art History 1","2D Design 1",
                    "Drawing 2","Color Theory 2","Art History 2","2D Design 2",
                    "Painting 1","3D Design 1","Sculpture 1","Art Criticism 1",
                    "Painting 2","3D Design 2","Sculpture 2","Art Criticism 2",
                    "Digital Art 1","Printmaking 1","Photography 1","Art Research 1",
                    "Digital Art 2","Printmaking 2","Photography 2","Art Research 2",
                    "Portfolio Development 1","Mixed Media","Installation Art","FA Elective 1",
                    "Portfolio Development 2","FA Capstone 1","FA Capstone 2","FA Elective 2"
                },
                [15] = new[] {
                    "Intro to Education","Child Development 1","The Teaching Profession 1","Curriculum Dev 1",
                    "Child Development 2","The Teaching Profession 2","Curriculum Dev 2","Assessment 1",
                    "Assessment 2","Facilitating Learning 1","Educational Technology 1","Field Study 1",
                    "Facilitating Learning 2","Educational Technology 2","Field Study 2","Content Area 1",
                    "Content Area 2","Inclusive Education 1","Education Research 1","BSED Elective 1",
                    "Content Area 3","Inclusive Education 2","Education Research 2","BSED Elective 2",
                    "Content Area 4","Teaching Internship 1","Classroom Management","BSED Capstone 1",
                    "Content Area 5","Teaching Internship 2","Teaching Internship 3","BSED Capstone 2"
                },
                [16] = new[] {
                    "Foundations of Education","Child Development 1","Teaching Reading 1","Math for Teachers 1",
                    "Child Development 2","Teaching Reading 2","Math for Teachers 2","Science for Teachers 1",
                    "Science for Teachers 2","Social Studies for Teachers 1","Assessment in Elementary 1","Educational Technology 1",
                    "Social Studies for Teachers 2","Assessment in Elementary 2","Educational Technology 2","Special Education 1",
                    "Special Education 2","Classroom Management 1","BEED Research 1","BEED Elective 1",
                    "Classroom Management 2","Mother Tongue Teaching","BEED Research 2","BEED Elective 2",
                    "Values Education Teaching","Arts and Music Teaching","Field Study 1","BEED Capstone 1",
                    "PE and Health Teaching","Field Study 2","Teaching Internship","BEED Capstone 2"
                },
                [17] = new[] {
                    "Architectural Design 1","History of Architecture 1","Building Technology 1","Graphics 1",
                    "Architectural Design 2","History of Architecture 2","Building Technology 2","Graphics 2",
                    "Architectural Design 3","History of Architecture 3","Building Technology 3","Structural Systems 1",
                    "Architectural Design 4","History of Architecture 4","Building Technology 4","Structural Systems 2",
                    "Architectural Design 5","Urban Planning 1","Environmental Control 1","Arch Research 1",
                    "Architectural Design 6","Urban Planning 2","Environmental Control 2","Arch Research 2",
                    "Professional Practice 1","Architectural Utilities 1","Arch Elective 1","Arch Thesis 1",
                    "Professional Practice 2","Architectural Utilities 2","Arch Elective 2","Arch Thesis 2"
                },
                [18] = new[] {
                    "Intro to Multimedia","Digital Photography 1","Graphic Design 1","Animation Fundamentals 1",
                    "Digital Photography 2","Graphic Design 2","Animation Fundamentals 2","Video Production 1",
                    "Video Production 2","Web Design 1","3D Modeling 1","Motion Graphics 1",
                    "Web Design 2","3D Modeling 2","Motion Graphics 2","Game Design 1",
                    "Game Design 2","Interactive Media 1","MMA Research 1","MMA Elective 1",
                    "Interactive Media 2","Sound Design","MMA Research 2","MMA Elective 2",
                    "Visual Effects 1","Augmented Reality","MMA Elective 3","MMA Capstone 1",
                    "Visual Effects 2","MMA Elective 4","MMA Capstone 2","MMA Capstone 3"
                },
                [19] = new[] {
                    "Intro to Hospitality","Food and Beverage 1","Front Office Operations 1","Housekeeping Management 1",
                    "Food and Beverage 2","Front Office Operations 2","Housekeeping Management 2","Culinary Arts 1",
                    "Culinary Arts 2","Hotel Operations 1","Tourism Management 1","Event Management 1",
                    "Hotel Operations 2","Tourism Management 2","Event Management 2","Resort Management 1",
                    "Resort Management 2","Food Safety 1","HRM Research 1","HRM Elective 1",
                    "Food Safety 2","Hospitality Marketing","HRM Research 2","HRM Elective 2",
                    "Revenue Management","Convention Management","HRM Elective 3","HRM Capstone 1",
                    "Sustainable Tourism","HRM Elective 4","HRM Capstone 2","HRM Capstone 3"
                },
                [20] = new[] {
                    "Intro to Law","Obligations and Contracts 1","Legal Research 1","Political Law 1",
                    "Obligations and Contracts 2","Legal Research 2","Political Law 2","Criminal Law 1",
                    "Criminal Law 2","Civil Law 1","Corporation Law 1","Labor Law 1",
                    "Civil Law 2","Corporation Law 2","Labor Law 2","Taxation Law 1",
                    "Taxation Law 2","Evidence 1","Legal Writing 1","LM Elective 1",
                    "Evidence 2","International Law 1","Legal Writing 2","LM Elective 2",
                    "International Law 2","Legal Management Elective 1","LM Elective 3","LM Capstone 1",
                    "ADR and Arbitration","Legal Management Elective 2","LM Capstone 2","LM Capstone 3"
                }
            };

            foreach (var (courseId, subjects) in allMajors)
            {
                for (int i = 0; i < subjects.Length; i++)
                {
                    int yearLevel = (i / 8) + 1;
                    int semester = ((i % 8) / 4) + 1;
                    modelBuilder.Entity<Subject>().HasData(new Subject
                    {
                        Id = sid++,
                        Name = subjects[i],
                        Type = "Major",
                        Units = 3,
                        YearLevel = yearLevel,
                        Semester = semester,
                        CourseId = courseId
                    });
                }
            }
        }
    }
}