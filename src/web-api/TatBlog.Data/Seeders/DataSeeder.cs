using Azure.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;

namespace TatBlog.Data.Seeders
{
    // Tạo Migration
    // Add-Migration InitialCreate
    // Cập nhật Database
    // Update-Database -Verbose


    public class DataSeeder : IDataSeeder
    {
        private readonly BlogDbContext _dbContext;

        public DataSeeder(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Posts.Any()) return;

            var authors = AddAuthors();
            var categories = AddCategories();
            var tags = AddTags();
            var posts = AddPosts(authors, categories, tags);
            var books = AddBooks(authors, categories);
            var users = AddUsers();
            //var carts = AddCarts();
        }

        private IList<Author> AddAuthors() 
        {
            var authors = new List<Author>()
            {
                new()
                {
                    FullName = "Nguyễn Nhật Ánh",
                    UrlSlug = "nguyen-nhat-anh",
                    Email = "nguyen-nhat-anh.com",
                    JoinedDate = new DateTime(2020, 4, 21),
                    Notes = "Nguyễn Nhật Ánh là một nhà văn, nhà thơ, bình luận viên Việt Nam." +
                    "Ông được biết đến qua nhiều tác phẩm văn học về đề tài tuổi trẻ, các tác phẩm của ông " +
                    "rất được độc giả ưa chuộng và nhiều tác phẩm đã được chuyển thể thành phim"
                },
                new()
                {
                    FullName = "Đoàn Giỏi",
                    UrlSlug = "doan-gioi",
                    Email = "doan-gioi.com",
                    JoinedDate = new DateTime(2020, 4, 19),
                    Notes ="Đoàn Giỏi (17 tháng 5 năm 1925 – 2 tháng 4 năm 1989), là một nhà văn Việt Nam, " +
                    "hội viên Hội Nhà văn Việt Nam từ năm 1957. Ông có những bút danh khác như: Nguyễn Hoài, Nguyễn Phú Lễ, Huyền Tư"
                },
                new()
                {
                    FullName = "Dale Carnegie",
                    UrlSlug = "dale-carnegie",
                    Email = "dale-carnegie.com",
                    JoinedDate = new DateTime(2019, 5, 1),
                    Notes ="Dale Breckenridge Carnegie là một nhà văn và nhà thuyết trình Mỹ " +
                    "và là người phát triển các lớp tự giáo dục, nghệ thuật bán hàng, huấn luyện đoàn thể, " +
                    "nói trước công chúng và các kỹ năng giao tiếp giữa mọi người"
                },
                new()
                {
                    FullName = "Paulo Coelho",
                    UrlSlug = "paulo-coelho",
                    Email = "paulo-coelho.com",
                    JoinedDate = new DateTime(2020, 12, 10),
                    Notes = "Paulo Coelho (sinh ngày 24 tháng 8 năm 1947) là tiểu thuyết gia nổi tiếng người Brasil"
                },
                new()
                {
                    FullName = "Nick Vujicic",
                    UrlSlug = "nick-vujicic",
                    Email = "nick-vujicic.com",
                    JoinedDate = new DateTime(2020, 5, 30),
                    Notes = "Nicholas James \"Nick\" Vujicic là một người truyền bá Phúc Âm và diễn giả truyền cảm hứng người Úc gốc Serbia, " +
                    "khi được sinh ra đã không có tứ chi mà chỉ có 1 bàn chân và 2 ngón chân nhỏ"
                },
                //================================================5

                 new()
                {
                    FullName = "Bill Gates",
                    UrlSlug = "bill-gates",
                    Email = "bill-gates.com",
                    JoinedDate = new DateTime(2020, 5, 30),
                    Notes = "William Henry Bill Gates III (sinh ngày 28 tháng 10 năm 1955) là một doanh nhân người Mỹ, nhà từ thiện, tác giả" +
                    " và chủ tịch tập đoàn Microsoft, hãng phần mềm mà ông cùng với Paul Allen đã sáng lập ra. Ông luôn có mặt trong danh sách " +
                    "những người giàu nhất trên thế giới."
                },
                new()
                {
                    FullName = "Robert Toru Kiyosaki",
                    UrlSlug = "robert-toru-kiyosaki",
                    Email = "robert-toru-kiyosaki.com",
                    JoinedDate = new DateTime(2020, 7, 7),
                    Notes = "Robert Toru Kiyosaki (sinh ngày 8 tháng 4 năm 1947) là một nhà đầu tư, doanh nhân đồng thời là một tác giả người Mỹ." +
                    "Kiyosaki nổi tiếng bởi cuốn sách Rich Dad, Poor Dad (Cha Giàu, Cha Nghèo). Ông đã viết 18 cuốn sách, bán tổng cộng 26 triệu bản."
                },
                new()
                {
                    FullName = "Haro Aso",
                    UrlSlug = "haro-aso",
                    Email = "haroaso@gmail.com",
                    JoinedDate = new DateTime(2020, 7, 7),
                    Notes = "Haro Aso"
                },
                new()
                {
                    FullName = "Thích Nhất Hạnh",
                    UrlSlug = "thich-nhat-hanh",
                    Email = "thichnhathanh@gmail.com",
                    JoinedDate = new DateTime(2020, 4, 7),
                    Notes = "Thích Nhất Hạnh"
                }
                ,
                new()
                {
                    FullName = "Aka Akasaka",
                    UrlSlug = "aka-akasaka",
                    Email = "akaakasaka@gmail.com",
                    JoinedDate = new DateTime(2019, 4, 10),
                    Notes = "Aka Akasaka"
                },
                //================================================10

                new()
                {
                    FullName = "Từ Quang Á",
                    UrlSlug = "tu-quang-a",
                    Email = "tuquanga@gmail.com",
                    JoinedDate = new DateTime(2013, 10, 10),
                    Notes = "Từ Quang Á"
                },
                 new()
                {
                    FullName = "Blair Thomas Spa",
                    UrlSlug = "dr-blair-thomas-spa",
                    Email = "drblairthomasspa@gmail.com",
                    JoinedDate = new DateTime(2013, 12, 8),
                    Notes = "Dr Blair Thomas Spa"
                },
                  new()
                {
                    FullName = "Mickaël Launay",
                    UrlSlug = "mickael-launay",
                    Email = "mickaellaunay@gmail.com",
                    JoinedDate = new DateTime(2018, 1, 6),
                    Notes = "Mickaël Launay"
                },
                new()
                {
                    FullName = "Ngô Tất Tố",
                    UrlSlug = "ngo-tat-to",
                    Email = "ngotatto@gmail.com",
                    JoinedDate = new DateTime(2011, 3, 18),
                    Notes = "Ngô Tất Tố"
                },
                new()
                {
                    FullName = "Hàn Xuân Trạch",
                    UrlSlug = "han-xaun-trach",
                    Email = "hanxuantrach@gmail.com",
                    JoinedDate = new DateTime(2019, 3, 22),
                    Notes = "Hàn Xuân Trạch"
                },
                //================================================15

                new()
                {
                    FullName = "Dr Alanna Levine",
                    UrlSlug = "dr-alanna-levine",
                    Email = "dralannalevine@gmail.com",
                    JoinedDate = new DateTime(2017, 9, 20),
                    Notes = "Dr Alanna Levine"
                },
                new()
                {
                    FullName = "Đa tác giả",
                    UrlSlug = "da-tac-gia",
                    Email = "datacgia@gmail.com",
                    JoinedDate = new DateTime(2018, 9, 2),
                    Notes = "Đa tác giả"
                },
                new()
                {
                    FullName = "PGS Hà Nam",
                    UrlSlug = "ha-nam",
                    Email = "hanam@gmail.com",
                    JoinedDate = new DateTime(2015, 11, 20),
                    Notes = "PGS Hà Nam"
                },
                new()
                {
                    FullName = "Charles Morris",
                    UrlSlug = "charles-moris",
                    Email = "charlesmoris@gmail.com",
                    JoinedDate = new DateTime(2019, 1, 2),
                    Notes = "Charles Morris"
                },
                new()
                {
                    FullName = "Victor Hugo",
                    UrlSlug = "victor-hugo",
                    Email = "victorhugo@gmail.com",
                    JoinedDate = new DateTime(2010, 10, 12),
                    Notes = "Victor Hugo"
                },
                //================================================20
                 
            };

            _dbContext.Authors.AddRange(authors);
            _dbContext.SaveChanges();

            return authors;
        } 

        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
                new(){Name = "Chính trị – pháp luật", Description = "Là thể loại sách nói về pháp luật", UrlSlug = "chinhtri-phapluat", ShowOnMenu = true},
                new(){Name = "Kinh tế", Description = "Là thể loại sách nói về kinh tế", UrlSlug = "kinhte", ShowOnMenu = true},
                new(){Name = "Văn học nghệ thuật", Description = "Là thể loại văn học nghệ thuật", UrlSlug = "vanhocnghethuat", ShowOnMenu = true},
                new(){Name = "Tiểu thuyết", Description = "Là một thể loại văn xuôi có hư cấu", UrlSlug = "tieuthuyet", ShowOnMenu = true},
                new(){Name = "Tâm linh & Tôn giáo", Description = "Là thể loại nói về các bí ẩn về tâm linh, tôn giáo", UrlSlug = "tamly-tamlinh-tongiao", ShowOnMenu = true},
                //================================================5
                
                new(){Name = "Sách tự lực", Description = "Là sách được viết với mục đích hướng dẫn độc giả giải quyết những vấn đề cá nhân. Dòng sách lấy tên từ Self-Help, " +
                 "cuốn sách bán chạy nhất năm 1859 của Samuel Smiles, nhưng còn được biết đến và phân loại theo \"tự cải thiện\", một thuật ngữ bản hiện đại hóa của tự lực", UrlSlug = "sach-tu-luc", ShowOnMenu = true},
                new(){Name = "Thiếu nhi", Description = "Là những loại sách dành cho thiếu nhi", UrlSlug = "thieunhi", ShowOnMenu = true},
                new(){Name = "Truyện ngắn", Description = "Là thể loại truyện ngắn về một câu chuyện nào đó", UrlSlug = "truyenngan", ShowOnMenu = true},
                new(){Name = "Truyện tranh", Description = "Là thể loại về truyện tranh", UrlSlug = "truyentranh", ShowOnMenu = true},
                new(){Name = "Giáo trình", Description = "Là thể loại sách , tài liệu cụ thể, nói về các lĩnh vực nghiên cứu", UrlSlug = "giaotrinhgiaotrinh", ShowOnMenu = true},
                //================================================10
                
                new(){Name = "Khoa học viễn tưởng", Description = "Là thể loại sách nói vể khoa học, nói về một vấn đề mà không có thật ở hiện tại", UrlSlug = "khoahocvientuong", ShowOnMenu = true},
            };

            _dbContext.Categories.AddRange(categories);
            _dbContext.SaveChanges();

            return categories;
        }

        private IList<Tag> AddTags()
        {
            var tags = new List<Tag>()
            {
                new(){Name = "Review", Description = "Review", UrlSlug = "review"},
                new(){Name = "Sách mới", Description = "Sách mới", UrlSlug = "sach-moi"},
                new(){Name = "Sách hot", Description = "Sách hot", UrlSlug = "sach-hot"},
                new(){Name = "Đề xuất", Description = "Đề xuất", UrlSlug = "de-xuat"},
                new(){Name = "Hôm nay đọc gì", Description = "Hôm nay đọc gì", UrlSlug = "hom-nay-doc-gi"},

                new(){Name = "Sách của năm", Description = "Sách của năm", UrlSlug = "sach-cua-nam"},
                new(){Name = "Nên đọc", Description = "Nên đọc", UrlSlug = "nen-doc"},
                new(){Name = "Top 10", Description = "Top 10", UrlSlug = "top10"},
                new(){Name = "Giới trẻ", Description = "Giới trẻ", UrlSlug = "gioi-tre"},
                new(){Name = "Học hỏi", Description = "Học hỏi", UrlSlug = "hoc-hoi"},

                new(){Name = "Giáo dục", Description = "Giáo dục", UrlSlug = "giao-duc"},
                new(){Name = "Sách cho tâm hồn", Description = "Sách cho tâm hồn", UrlSlug = "sach-cho-tam-hon"},
                new(){Name = "Tư duy", Description = "Tư duy", UrlSlug = "giao-trinh"},
                new(){Name = "Tôn giáo", Description = "Tôn giáo", UrlSlug = "ton-giao"},
                new(){Name = "Anime", Description = "Anime", UrlSlug = "anime"},

                new(){Name = "Cẩm nang", Description = "Cho trẻ", UrlSlug = "cho-tre"},
                new(){Name = "Văn học", Description = "Văn học", UrlSlug = "van-hoc"},
                new(){Name = "Cũ mà hay", Description = "Toán học", UrlSlug = "toan-hoc"},
            };

            _dbContext.Tags.AddRange(tags);
            _dbContext.SaveChanges();

            return tags;
        }

        private IList<AppUser> AddUsers()
        {
            var users = new List<AppUser>()
            {
                new()
                {
                    Dob = new DateTime(2020, 4, 19),
                    Email = "hoangadmin@gmail.com",
                    FirstName = "Doan",
                    LastName = "Hoang",
                    UserName = "hoangadmin",
                    PhoneNumber = "09123980012",
                    PasswordHash = "hoang@0H",
                },
                new()
                {
                    Dob = new DateTime(2020, 5, 9),
                    Email = "sangadmin@gmail.com",
                    FirstName = "Do",
                    LastName = "Sang",
                    UserName = "sangadmin",
                    PhoneNumber = "09138787958",
                    PasswordHash = "sang@0S",
                },
                new()
                {
                    Dob = new DateTime(2020, 6, 26),
                    Email = "suongadmin@gmail.com",
                    FirstName = "Quang",
                    LastName = "Suong",
                    UserName = "suongadmin",
                    PhoneNumber = "0978369364",
                    PasswordHash = "suong@0S",
                },
            };

            _dbContext.Users.AddRange(users);
            _dbContext.SaveChanges();

            return users;
        }

        //private AppUser AddUserItem(string email, string firstName, string lastName, string userName, string password, string phoneNumber, int day, int month, int year)
        //{
        //    var user = new AppUser()
        //    {
        //        Dob = new DateTime(year, month, day),
        //        Email = email,
        //        FirstName = firstName,
        //        LastName = lastName,
        //        UserName = userName,
        //        PhoneNumber = phoneNumber,
        //        PasswordHash = password,
        //    };
        //    return user;
        //}

        private IList<Post> AddPosts(
            IList<Author> authors,
            IList<Category> categories,
            IList<Tag> tags
            )
        {
            var posts = new List<Post>()
            {
                new()
                {
                    Title = "Tôi thấy hoa vàng trên cỏ xanh",
                    ShortDescription = "Là một tiểu thuyết dành cho thanh thiếu niên của nhà văn Nguyễn Nhật Ánh, xuất bản lần đầu tại Việt Nam " +
                    "vào ngày 9 tháng 12 năm 2010 bởi Nhà xuất bản Trẻ với phần tranh minh họa do Đỗ Hoàng Tường thực hiện.",
                    Description = "Sách Tôi thấy hoa vàng trên cỏ xanh gợi nhớ lại một thời tuổi thơ hồn thiên, mơ mộng. Những ngày Tường trở thành chú chim xanh chuyên giao thư qua lại giữa chú Đàn và chị Vinh nhưng phải thật khéo vì nếu cha chị Vinh biết thì cả ba xong đời.\r\n\r\nHay những lúc nghe chuyện ma, hai anh em sợ đến nỗi bị nhát là sẽ chạy tán loạn, đến khi về nhà còn bị đánh cho một trận vì tội con trai mà lại sợ ma. Dẫu yếu bóng vía là thế nhưng khi nghe kể về xóm Miễu có ma cọp thì hai anh em vẫn nổi máu tò mò và đồi đi khám phá.\r\n\r\nCái thời mà smartphone còn chưa xuất hiện, những người yêu nhau sẽ lén trao nhau từng bức thư tay để bày tỏ tâm tình. Thiều thương Mận nhưng không dám nói, viết thư tay còn chưa kịp trao thì đã bị cô giáo bắt được và đọc cho cả lớp nghe. “Những ngày ẩm ương, chưa lớn mà cũng chẳng còn nhỏ, có ai chưa từng dõi mắt nhìn theo một ai”.\r\n\r\nTình anh em là một trong những chủ đề chính của truyện. Dù đôi lúc anh lớn là Thiếu có vô tình đối xử chưa tốt với em nhưng Tường vẫn luôn thương anh và lo lắng cho anh. Đi chơi về bị ba đánh, Thiều thì vắt chân lên cổ bỏ chạy còn Tường ở lại chịu trận thay cho anh hai. Tường thay anh làm hết các công việc trong nhà chỉ vì nghe mẹ bảo “để yên cho anh hai học bài”.\r\n\r\nChi tiết cảm động nhất truyện là khi anh hai bị đánh, Tường giúp anh trả thù nhưng lại tự mình chịu đòn vì không để anh bị oan. Ở cái tuổi dở trăng dở đèn, khi nội tâm và tính cách có nhiều biến động, Thiều đã không ít lần để cơn nóng giận bùng cháy và là tổn thương em trai. \r\n\r\nMọi thứ chợt hiện ra trong đầu Thiều và cả nỗi ân hận như dao khắc vào tim Thiều, làm Thiều đứng sững như người mất hồn mà không hay rằng thằng Tường vẫn còn nằm ngửa dưới nền nhà. Thời gian như tiếp tục trôi qua khi thằng Thiều nghe tiếng thằng Tường kêu “Giúp em với, anh Hai!”.\r\n\r\nKhi Thiều xốc nách nó thì đã rên lên “Đau em!” và thấy nước mắt nó úa ra. Sau khi thấu hiểu sự tình, Thiều liền đi tìm ông Xung  cứu Tường nhưng trước đi tường lại kêu anh hai bảo là: “Anh đừng nói với ông Xung là anh đánh em nhé, hãy bảo là em trèo cây bị tuột tay rơi xuống đất.”\r\n\r\nGợi ý sách hay: Ông trăm tuổi trèo qua cửa sổ và biến mất – cuốn sách làm sống dậy khát vọng sống trẻ, sống tự do\r\n\r\nTình anh em là một trong những chủ đề chính của truyện. Dù đôi lúc anh lớn là Thiếu có vô tình đối xử chưa tốt với em nhưng Tường vẫn luôn thương anh và lo lắng cho anh. Đi chơi về bị ba đánh, Thiều thì vắt chân lên cổ bỏ chạy còn Tường ở lại chịu trận thay cho anh hai. Tường thay anh làm hết các công việc trong nhà chỉ vì nghe mẹ bảo “để yên cho anh hai học bài”.\r\n\r\nChi tiết cảm động nhất truyện là khi anh hai bị đánh, Tường giúp anh trả thù nhưng lại tự mình chịu đòn vì không để anh bị oan. Ở cái tuổi dở trăng dở đèn, khi nội tâm và tính cách có nhiều biến động, Thiều đã không ít lần để cơn nóng giận bùng cháy và là tổn thương em trai. \r\n\r\nMọi thứ chợt hiện ra trong đầu Thiều và cả nỗi ân hận như dao khắc vào tim Thiều, làm Thiều đứng sững như người mất hồn mà không hay rằng thằng Tường vẫn còn nằm ngửa dưới nền nhà. Thời gian như tiếp tục trôi qua khi thằng Thiều nghe tiếng thằng Tường kêu “Giúp em với, anh Hai!”.\r\n\r\nKhi Thiều xốc nách nó thì đã rên lên “Đau em!” và thấy nước mắt nó úa ra. Sau khi thấu hiểu sự tình, Thiều liền đi tìm ông Xung  cứu Tường nhưng trước đi tường lại kêu anh hai bảo là: “Anh đừng nói với ông Xung là anh đánh em nhé, hãy bảo là em trèo cây bị tuột tay rơi xuống đất.”\r\n\r\nGợi ý sách hay: Ông trăm tuổi trèo qua cửa sổ và biến mất – cuốn sách làm sống dậy khát vọng sống trẻ, sống tự do",
                    Meta = "Tôi thấy hoa vàng trên cỏ xanh",
                    UrlSlug = "toi-thay-hoa-vang-tren-co-xanh",
                    ImageUrl = "https://revisach.com/wp-content/uploads/2020/07/review-sach-toi-thay-hoa-vang-tren-co-xanh-nguyen-nhat-anh-3.png",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 1860,
                    Author = authors[0],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[0], 
                        tags[4],
                        tags[5],
                        tags[8]
                    }
                },

                new()
                {
                    Title = "Review sách Mắt Biếc – Nguyễn Nhật Ánh",
                    ShortDescription = "Một tác phẩm được nhiều người bình chọn là hay nhất của nhà văn này. Một tác phẩm đang được dịch và giới thiệu tại Nhật Bản (theo thông tin từ các báo)…Bởi sự trong sáng của một tình cảm, bởi cái kết thúc rất, rất buồn khi suốt câu chuyện vẫn là những điều vui, buồn lẫn lộn (cái kết thúc không như mong đợi của mọi người)." +
                    " Cũng bởi, mắt biếc… năm xưa nay đâu (theo lời một bài hát).",
                    Description = "“Mắt biếc” – một tâm hồn lãng mạn, một tình yêu nồng nàn nhưng lại có kết cục buồn. Cuốn sách “Mắt biếc” của Nguyễn Nhật Ánh thực sự đã chạm vào tâm hồn của những kẻ đang yêu, đã và đang dành cả thanh xuân, tuổi trẻ của mình để yêu đơn phương một người nào đó. Không còn xa lạ với những câu chuyện tình yêu đơn phương của Nguyễn Nhật Ánh nhưng đến với “Mắt biếc” việc xây dựng hình tượng và nội dung có phần khác. Vẫn với những ngôn từ giản đơn, gần gũi, cuốn sách sẽ gieo lại trong lòng độc giả một nỗi niềm nuối tiếc, chơi vơi, vừa yêu vừa giận.\r\n\r\n“Mắt biếc” được Nguyễn Nhật Ánh sáng tác vào năm 1990. Và rồi sau 30 năm ra mắt độc giả, vào một ngày tháng 2 Ngạn và Hà Lan lại cùng nhau rời khỏi những trang sách và bước vào thế giới một dự án điện ảnh cùng tên vô cùng được mong đợi. Các bạn khi cầm cuốn sách trên tay sẽ bị ấn tượng ngay bởi tiêu đề cùng cách thiết kế bìa sách nhẹ nhàng.\r\n\r\nTiêu đề chỉ vỏn vẹn hai chữ “Mắt biếc” nhưng đã mở ra rất nhiều cung bậc cảm xúc cho độc giả bởi ai cũng biết mắt biếc là một đôi mắt đẹp nhưng lại mang nét buồn. Phần nào cũng gợi nên một cốt truyện có nội dung phảng phất những nỗi buồn. Cách thiết kế bìa sách mang tới một cảm giác dễ chịu với phông xanh chủ đạo và hình ảnh một người con trai ngồi đánh đàn bên cô gái dưỡi tán cây được phác họa một cách đơn giản.\r\n\r\nCuốn sách kể về cuộc đời của chàng trai thuộc trường phái cổ điển tên Ngạn được sinh ra và lớn lên trong ngôi làng Đo Đo ở vùng quê Quảng Nam. Tuổi thơ của cậu gắn liền với cô bạn hàng xóm Hà Lan, một cô gái mang hơi hướng hiện đại và nổi bật với đôi mắt biếc. Tuổi thơ của cả hai là chuỗi những kỉ niệm đẹp ở làng, bên đồi sim, cùng nhau cởi truồng tắm mưa, những ngày tiểu học giành nhau đánh trống trường,…và là những câu nói hồn nhiên đáng yêu cực kì của hai đứa trẻ.\r\n\r\nCâu chuyện được mở đầu với những hình ảnh nhẹ nhàng, màu sắc tươi sáng nhất, âm thanh yên bình nhất. Cứ ngỡ rằng câu chuyện sẽ tiếp tục nhẹ nhàng như thế, bởi lẽ Ngạn đã dần dần nảy sinh tình cảm với Hà Lan, một đôi thanh mai trúc mã tưởng chừng rồi sẽ có kết quả tốt đẹp. Và giông bão nổi lên ở cái thời điểm Hà Lan rời chốn làng quê để lên thành phố học hành và bị cám dỗ bởi thành thị xa hoa.\r\n\r\nVà rồi, Hà Lan yêu say đắm Dũng – một thanh niên nhà giàu, sành điệu, giỏi vỏ nhưng lại mà một kẻ chuộng tự do, thiếu đứng đắn. Điều này đã làm cho Ngạn vô cùng đau lòng, bởi điều Ngạn mong muốn nhất bây giờ chính là Hà Lan được hạnh phúc. Mỗi khi Dũng làm Hà Lan đau lòng thì cô lại tìm đến Ngạn, anh trở thành điểm tựa, nơi trút bầu tâm sự của cô một cách tự nhiên, mỗi khi như thế Ngạn lại càng thấy đau lòng hơn như có hàng trăm con dao khứa vào trái tim của mình.\r\n\r\nVà đỉnh điểm của nỗi đau chính là Hà Lan có thai với Dũng nhưng lại bị Dũng ruồng bỏ. Hà Lan đặt tên cho con là Trà Long và đành gửi về cho bà ngoại chăm sóc. Hà Lan lặng lẽ và sâu sắc hơn bất cứ người con gái nào khác nên cô đã không chấp nhận tình yêu của Ngạn dù cô biết Ngạn yêu cô đến nhường nào.\r\n\r\nCho dù Nguyễn Nhật Ánh đã cố giành lấy sự đồng cảm của độc giả dành cho Nhạn khi dốc hết lòng để thương Hà Lan, thương đôi mắt biếc thân quen, thương cô đến đau lòng, một tình yêu rộng lượng đến nỗi không cần được hồi đáp. Nhưng vẫn không thể phủ nhận một sự thật rằng, Ngạn và Hà Lan của ngày nào vốn dĩ đã sống ở 2 thế giới khác nhau hoàn toàn, cho dù khởi đầu chung một môi trường giáo dục.\r\n",
                    Meta = "Review sách Mắt Biếc – Nguyễn Nhật Ánh",
                    UrlSlug = "review-sach-mat-biec-nguyen-nhat-anh",
                    ImageUrl = "https://sachhay24h.com/uploads/images/2020/T5/480/top-7-sach-nguyen-nhat-anh.PNG",
                    Published = true,
                    PostedDate = new DateTime(2022, 10, 3, 11, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 200,
                    Author = authors[0],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[0],
                        tags[5],
                        tags[4],
                        tags[11]
                    }
                },

                new()
                {
                    Title = "Đất rừng Phương Nam",
                    ShortDescription = " Là truyện được biết đến nhiều nhất của ông. Đây được xem là bài ca tuyệt vời về thiên nhiên và con người Nam Bộ. Cuốn tiểu thuyết kể về cuộc đời phiêu bạt của cậu bé An. " +
                    "Bối cảnh truyện diễn ra ở các tỉnh miền Tây Nam Bộ vào những năm 1945, sau khi thực dân Pháp quay trở lại xâm chiếm vùng đất này..",
                    Description = "Xuyên suốt tập sách, thiên nhiên như ngự trị qua từng con chữ, nhuốm màu sắc sơ khai khó tả. Khu rừng U Minh thượng  kỳ vỹ mênh mông mang một vẻ dữ dội, hoang sơ và lộng lẫy lạ thường. Nơi Đại Ngàn đầy nắng muôn loài muôn vật, cây cối cao to xanh rờn mát rượi phủ bóng rợp mặt đất. Xen lẫn trong đó thoảng mùi ẩm ướt mát lành từ đất và các con lạch nhỏ bé chảy róc rách qua các rặng cây, rồi đổ về nơi sông suối. Ngay cả khu rừng đước cao to với các dòng nước len lỏi đục ngầu cũng dường như hoang dã và ma quái lạ thường dưới lớp sương của màn đêm. Những sinh vật lạ lẫm, khoe ra bộ lông cánh đủ màu, những cũng có những loài khiến người ta run mình bởi sự đồ sộ dữ dằn như chẳng thuộc về trần thế.\r\n\r\nKhu chợ Năm Căn như đối lập với U Minh thượng uy nghiêm bởi vẻ tấp nập, lao nhao của những cô gái người Hoa đang bán từng cây chim cuộn chỉ, những người lái buôn ra sức chào hàng, những món hàng hóa thơm lừng sặc sỡ, nơi ánh hoàng hôn kiêu kỳ buông xuống như một giấc mơ. Tất cả đều khiến cho ta cứ muốn ở lại đây mãi, trong không khí ồn ào nhưng vui tươi tấp nập này nơi mảnh đất Cà Mau. Từng vùng đất, từng cảnh vật nhuốm vẻ đẹp phiêu lưu chảy qua từng ngọn lá , róc rách qua các tảng đá con như khiêu khích trí tò mò của nhân loại. Tuy nhiên ẩn sau con đường vàng óng đó là những chông gai sừng sững chờ đợi để vượt qua, nhưng “hỡi thiên nhiên dữ dội và nham hiểm, ngươi hãy coi chừng. Không một sức mạnh nào trong ngươi mà con người không khuất phục nổi đâu!”.\r\n\r\nNhững con người trong tác phẩm vừa chân chính vừa mang vẻ xót xa, từng người một đem cho tôi những xúc cảm khác nhau. Mỗi người họ như lột tả một xã hội thu nhỏ thời Kháng chiến. Bà dì Tư Mắm keo kiệt với giọng nói ngọt ngào sắc lẻm, biết thấu biết tình, luôn kè kè chiếc bóp đen bóng mỡ phình to. Lão Ba Ngù vui tính hào sảng nhưng có thể trở nên nghiêm túc bất cứ lúc nào. Cậu bé An tinh ranh trải sự đời, lanh lợi và có óc phán đoán khôn lường. Gia đình ông Hai và chú Võ Tòng đại diện cho tầng lớp nông dân nghèo bị bóc lột đến tận cùng, lang thang chạy trốn bọn địa chủ ác tà từ nơi này sang nơi khác, bị tù đày rồi phải dứt áo ra đi, bỏ cả quê hương nơi chôn rau cắt rốn.  Tuy “ nghèo như chiếc lá rụng xuống sông, nươc đi tới đâu mình theo tới đó! Huống chi bây giờ lại gặp lúc giặc đánh lung tung…”, mặc cho những chiếc gai bề khổ đâm thấu họ, những con người ấy vẫn  hào sảng trung hậu, ngay thẳng, một lòng một dạ vì Tổ quốc quê hương đồng bào.\r\n\r\nHẳn là ai cũng đã đoán ra, đó là bọn Việt gian bán nước không ghê tay vì hào quang của những đồng tiền dơ bẩn. Chúng thậm chí còn đáng trách gấp vạn lần so với lũ Thực dân pháp bởi không gì kinh tởm hơn là phản quốc. Mụ vợ Tư Mắm được nhắc xuyên suốt qua nửa đầu tác phẩm bởi sự quỷ quyệt và gian xảo của ả. Ai cũng ớn lạnh với đôi mắt của mụ đàn bà này, nó đẹp một cách ác độc, ánh lên tia nhìn liếc xéo sắc lẻm, đáng sợ hơn bất cứ gì. Nhưng gieo gió thì gặt bão, những kẻ phản bội sẽ không bao giờ thắng cuộc. Ả ta đã phải trả giá đắt cho những tội ác nhơ bẩn của mình, thứ đã cướp đi bao nhiêu sinh mạng người vô tội.",
                    Meta = "Đất rừng Phương Nam",
                    UrlSlug = "dat-rung-phuong-nam",
                    ImageUrl = "https://reviewsach.net/wp-content/uploads/2020/04/review-sach-dat-rung-phuong-nam.jpg",
                    Published = true,
                    PostedDate = new DateTime(2021, 1, 12, 1, 25, 0),
                    ModifiedDate = null,
                    ViewCount = 1260,
                    Author = authors[1],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[0],
                        tags[7],
                        tags[16],
                        tags[3],
                        tags[6]
                    }
                },

                new()
                {
                    Title = "Đắc Nhân Tâm",
                    ShortDescription = "Là một quyển sách nhằm tự giúp bản thân (self-help) bán chạy nhất từ trước đến nay. Quyển sách này do Dale Carnegie viết và đã được xuất bản lần đầu vào năm 1936, nó đã được bán 15 triệu bản trên khắp thế giới.[1][2] Nó cũng là quyển sách bán chạy nhất của New York Times trong 10 năm." +
                    " Tác phẩm được đánh giá là cuốn sách đầu tiên và hay nhất trong thể loại này, có ảnh hưởng thay đổi cuộc đời đối với hàng triệu người trên thế giới.",
                    Description = "Dù cho cuốn sách Đắc Nhân Tâm này đã được tái bản rất nhiều lần, nhưng cho đến nay qua bao nhiêu thế hệ người đọc, nó vẫn luôn là cuốn sách thu hút được lượng người đọc đông đảo bởi giá trị nội dung vẫn luôn còn mãi với thời gian. \r\n\r\nNhắc thêm một chút về tác giả Dale Carnegie, ông là một chuyên gia tâm lý, một nhà ngoại giao, chính trị và là giảng viên người Mỹ rất nổi tiếng của thế kỷ trước. Ông thường xuyên chia sẻ các bí quyết, kinh nghiệm thành công của mình đến tất cả mọi người cho bằng việc cho ra mắt các cuốn sách với chủ đề dạy làm người và kĩ năng sống được nhiều người đón nhận. \r\n\r\nĐối với cuốn sách Đắc Nhân Tâm này được chia làm 4 phần. Mỗi phần trong cuốn sách sẽ tương ứng với một bài học và các bí quyết khác nhau.\r\n\r\nPhần 1 nói về nghệ thuật ứng xử căn bản của mỗi con người, bao gồm những bí quyết, kinh nghiệm và cả các bài học về việc đối nhân xử thế trong các mối quan hệ xã hội mà bạn nên lưu tâm đến. \r\n\r\nDù cho cuốn sách Đắc Nhân Tâm này đã được tái bản rất nhiều lần, nhưng cho đến nay qua bao nhiêu thế hệ người đọc, nó vẫn luôn là cuốn sách thu hút được lượng người đọc đông đảo bởi giá trị nội dung vẫn luôn còn mãi với thời gian. \r\n\r\nNhắc thêm một chút về tác giả Dale Carnegie, ông là một chuyên gia tâm lý, một nhà ngoại giao, chính trị và là giảng viên người Mỹ rất nổi tiếng của thế kỷ trước. Ông thường xuyên chia sẻ các bí quyết, kinh nghiệm thành công của mình đến tất cả mọi người cho bằng việc cho ra mắt các cuốn sách với chủ đề dạy làm người và kĩ năng sống được nhiều người đón nhận. \r\n\r\nĐối với cuốn sách Đắc Nhân Tâm này được chia làm 4 phần. Mỗi phần trong cuốn sách sẽ tương ứng với một bài học và các bí quyết khác nhau.\r\n\r\nPhần 1 nói về nghệ thuật ứng xử căn bản của mỗi con người, bao gồm những bí quyết, kinh nghiệm và cả các bài học về việc đối nhân xử thế trong các mối quan hệ xã hội mà bạn nên lưu tâm đến. \r\n\r\nPhần 2 của cuốn sách sẽ hướng dẫn cho bạn những bí quyết hữu ích trong việc tạo ra sự thiện cảm đối với người đối diện, nhờ đó giúp cho những người xung quanh luôn yêu quý và trân trọng tình cảm của bạn hơn.\r\n\r\nPhần 3 được xem là một phần rất quan trọng và sẽ đem lại cho bạn rất nhiều bài học bổ ích nhất liên quan đến lĩnh vực tâm lý học, đó là chỉ cho bạn các phương pháp và bí quyết giúp bạn và những người khác có chung về suy nghĩ và quan điểm trong cuộc sống.\r\n\r\nPhần 4, phần cuối cùng của cuốn sách Đắc nhân tâm, tác giả sẽ bày cho bạn những cách để chuyển hóa cảm xúc và suy nghĩ của một người khác từ tiêu cực chuyển thành tích cực mà không để xảy ra sự hận thù hay oán trách, dù cho đây không phải là một việc làm đơn giản chút nào.  ",
                    Meta = "Đắc Nhân Tâm",
                    UrlSlug = "dac-nhan-tam",
                    ImageUrl = "https://www.reader.com.vn/uploads/images/2019/10/31/22/dac-nhan-tam-1_600x525.jpg",
                    Published = true,
                    PostedDate = new DateTime(2020, 1, 3, 5, 23, 0),
                    ModifiedDate = null,
                    ViewCount = 569,
                    Author = authors[2],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[15],
                        tags[12],
                        tags[8],
                        tags[2],
                        tags[3],
                        tags[9]
                    }
                },

                new()
                {
                    Title = "Quẳng Gánh Lo Đi Và Vui Sống",
                    ShortDescription = "Là một sách tự lực của tác giả người Mỹ Dale Carnegie, được viết vào năm 1948. Bản Việt Ngữ do Nguyễn Hiến Lê dịch năm 1955 tại Sài Gòn và đưa vào tủ sách Học làm người. " +
                    "Quyển sách này là một cẩm nang về cách làm việc và vui sống không bị lo âu.",
                    Description = "Tôi tin rằng nếu bạn nào đã từng đọc qua cuốn sách “Đắc nhân tâm” thì bạn sẽ biết đến mức độ ảnh hưởng và nổi tiếng của Dale Carnigie. “Quẳng gánh lo đi và vui sống” cũng như vậy dù trải qua lớp bụi của thời gian nhưng những giá trị trong cuốn sách đem lại vẫn còn nguyên vẹn đến ngày hôm nay.\r\n\r\nHiện tại trên Fahasa cuốn sách này đứng thứ 6 trong top 100 cuốn sách bán chạy nhất trong tuần. Nội dung cuốn sách bao gồm 6 phần, mỗi một phần đều có đầy đủ những nguyên tắc để phát triển kĩ năng của bản thân cùng với đó là những câu chuyện thực tế. Trong sách còn có những trích dẫn, câu nói kinh điển giúp chúng ta thay đổi suy nghĩ, có cái nhìn khác về những điểm tiêu cực trong cuộc sống.\r\n\r\nCuộc sống này đúng là chưa từng dễ dàng với một ai cả, mỗi một giai đoạn đều sẽ đem đến cho bạn những thử thách khác nhau. Những nỗi lo lắng về học hành, tiền bạc, công việc, các mối quan hệ làm cho chúng ta đau đầu nhưng đừng mãi chìm đắm trong nó, hãy để bản thân được nghỉ ngơi bằng cách tìm kiếm niềm vui ở chính mình. Muốn có dũng khí đối diện với áp lực trong cuộc sống điều bạn cần phải có đó là sự chuẩn bị thật tốt từ tâm hồn cho đến kĩ năng. Hãy dũng cảm hơn, đừng bi quan về cuộc sống này!\r\n\r\nChúng ta đều biết rằng lo lắng không thể giải quyết được vấn đề nhưng có một sự thật là không phải ai cũng đều biết điều chỉnh cảm xúc, thoát ra khỏi những lo lắng. Có những ngày cuộc sống xung quanh bốn bể chỉ toàn là tiêu cực, thật khó chịu đúng không nào? Đừng quá sốt sắng bạn nhé, cứ bình tĩnh, nhìn nhận mọi thứ theo chiều hướng tích cực. Nếu cảm thấy áp lực quá bạn có thể sống chậm lại, nghĩ về những điều tốt đẹp nhất.\r\n\r\nLàm gì có đau khổ nào mãi không dứt được, làm gì có cảm xúc tiêu cực nào chìm nghỉm mãi trong lòng mà không thể nguôi được. Nếu bạn mất đi một điều gì đó, ông trời nhất định sẽ bù đắp khoảng trống đó cho bạn. Vì cuộc sống này có quy luật bù trừ mà, đừng bi quan chúng ta rồi sẽ hạnh phúc.\r\n\r\nQuẳng gánh lo đi và vui sống giúp chúng ta vượt qua được những cảm xúc lo lắng, vững tin trên con đường bước đến thành công. Từ những phân tích, chứng minh của Tác giả về cách thoát khỏi gánh nặng lo âu, mỗi chúng ta đều có thể áp dụng vào cuộc sống của mình. Hãy để “Quẳng gánh lo đi và vui sống” là động lực để bạn sống tốt hơn mỗi ngày nhé.\r\n\r\nNgay từ hôm nay chúng ta hãy thôi làm phiền quá khứ, những chuyện đã qua cứ để nó nhẹ nhàng trôi qua và cũng đừng quá lo lắng về tương lai. Bạn của hiện tại là tốt nhất rồi. Tôi chọn hôm nay, tôi chọn niềm vui. Còn bạn thì sao?\r\n",
                    Meta = "Quẳng Gánh Lo Đi Và Vui Sống",
                    UrlSlug = "quang-ganh-lo-di-va-vui-song",
                    ImageUrl = "https://muagitot.com/images/news/2022/08/24/large/quang-ganh-lo-di-va-vui-song_1661313506.jpg.webp",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 1, 7, 2, 0),
                    ModifiedDate = null,
                    ViewCount = 560,
                    Author = authors[2],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[0],
                        tags[2],
                        tags[8],
                        tags[11]
                    }
                },

                //================================================5

                new()
                {
                    Title = "Tham Vọng Lớn Lao Và Quá Trình Hình Thành Đế Chế Microsoft",
                    ShortDescription = "Tham Vọng Lớn Lao Và Quá Trình Hình Thành Đế Chế Microsoft (Tái Bản 2022). Trong tiết lộ thú vị này, " +
                    "hai ph óng viên điều tra Wallace và Erickson đã lần theo bước chân của Gates từ những ngày còn là một hac. Một phần doanh nhân, một phần lập dị, Gates đã trở thành nhân vật quyền.",
                    Description = "Đọc mới trải nghiệm sự nhiệt huyết, khắc khe, tận tâm tận lực của Bill để hình thành một đế chế của riêng mình theo cách của riêng ông.\r\n\r\nLàm việc hăng say đến quên mình. Bạn không thể tưởng tượng được một ngày chỉ dành 3-4 tiếng để ngủ, còn lại là thời gian làm việc của một cậu bé chỉ 17-18 tuổi. Tuổi mà các chàng trai trẻ cùng lứa chỉ dành thời gian để chơi bời – cua gái nhiều hơn là công việc. Mình xin mạng phép review sơ lược về cuốn sách này.\r\n\r\nChương 1: Thời niên thiếu\r\n\r\nKể về Bill Gates – ra đời trong 1 gia đình khá giả, có niềm đam mê, khát khao làm mọi việc một cách hoàn hảo nhất. Đam mê máy tính – phần mềm từ khi nó vừa ra đời – Học đến năm 2 thì ý định bỏ học để thành lập cty riêng – Lúc này là ổng đỉnh trong việc viết phần mềm sơ khai rùi – Hack vào trong hệ thống thống kê giờ sử dụng máy tính để giảm giờ ông sử dụng xuống nhằm mục đích trả tiền ít lại. (hacker đời đầu vì lúc này sử dụng máy tính ở trường đại học phải trả phí) – mém bị công an bắt – bị trường cảnh cáo.\r\n\r\nChương 2: Thời cơ đang đến\r\n\r\nLúc này quen với một số người trong đó có bạn thân là Paul Allen – chơi thân cùng chung ý tưởng => Microsoft ra đời, lúc này chỉ viết phần mềm bằng các lệnh đơn giản nhưng méo ai làm đc ngoại trừ 2 ông này. Kiểu đi trước thời đại. Tới chương này thì sách dùng nhiều từ chuyên ngành về máy tính hơn. Hơi khó hiểu tí. Ví dụ: BASIC , 64bit,… mình không rành về máy tính nên cũng tra gg phần này :v. Nói chung chương này là ổng quyết định nghỉ học lúc đang học năm 2 để mở cty vs Paul\r\n\r\nChương 3: Những chàng trai Microsoft\r\n\r\nNói về tuyển các thành viên, đa số nhiều người lớn tuổi hơn Gates, môi trường làm việc trong cty như ở nhà. Văn phòng được miêu tả khá bề bộn, nhân viên cũng chỉ tập trung vào công việc, ít quan tâm đến bề ngoài (như Bill – phỏng vấn mà còn ko để ý mình mặc áo rách nách cả 2 bên)\r\n\r\nChương 4: Làm ăn với “Anh cả”\r\n\r\nBắt đầu lớn mạnh làm ăn chung vs các ông lớn điển hình như IBM, Apple, Xerox,…\r\n\r\nChương 5: Lớn mạnh\r\n\r\nLúc này kể về các sự kiện kí kết làm ăn lớn. Tung ra Microsoft Word vs Excel như cuộc cách mạng nền máy tính – công nghệ. Lúc này người bạn thân nhất vì làm việc quá nhiều mà bệnh. Ung thư bạch cầu gì đó phải xạ trị nên quyết định nghỉ việc. Gates đã kiếm người thay thế nhưng dừng như chẳng có ai thay thế đc Allen. Nhưng rồi cũng ổn – lúc này Micro ăn phốt cũng nhiều lắm.\r\n\r\nChương 6: Vua một cõi\r\n\r\nTới giờ là bá chủ trong giới rùi nên các ông lớn quay ra kiện giành thị phần. Ko có gì cũng lôi ra kiện. Nhất là cha Apple, đọc mà thấy Apple kiện Micro ăn cắp bản quyền phải nói N lần. Có nhắc đến Steven Jobs bị đuổi ra khỏi ban quản lý Apple (này để mình đọc cuốn Steven Jobs rùi xác nhận sau, này hơi phi lí, chưa biết thật hư sao)\r\n\r\nRa đời Window 3.0 như cuộc cách một lần nữa. Giá cổ phiếu từ 21$ khi lên sàn đạt đỉnh thời điểm đó là 114$ sau vài năm. Chính thức thành tỷ phú trẻ nhất nước Mỹ. Lúc này ổng mới 31 tuổi.",
                    Meta = "Tham vong lon lao va qua trinh hinh thanh de che microsoft",
                    UrlSlug = "tham-vong-lon-lao-va-qua-trinh-hinh-thanh-de-che-microsoft",
                    ImageUrl = "http://timkiemkhoinghiep.com/wp-content/uploads/2020/02/Gioi-thieu-Bill-Gates-Tham-Vong-Lon-Lao-Va-Qua-Trinh-Hinh-Thanh-De-Che-Microsoft.jpg",
                    Published = true,
                    PostedDate = new DateTime(2020, 3, 30, 10, 45, 0),
                    ModifiedDate = null,
                    ViewCount = 800,
                    Author = authors[5],
                    Category = categories[1],
                    Tags = new List<Tag>()
                    {
                        tags[9],
                        tags[12],
                        tags[10],
                        tags[0]
                    }
                },

                new()
                {
                    Title = "Đừng cố làm người tốt trong mắt tất cả mọi người",
                    ShortDescription = "“Đừng cố làm người tốt trong mắt tất cả mọi người” điều này sẽ rất vô nghĩa. Thế giới có vô vàn kiểu người, có người tốt, người xấu và trong mắt người xấu thì bạn khó có thể trở nên tốt đẹp. Chúng ta chỉ cần sống cuộc đời mình yêu thích, làm những việc mình thích và với một phiên bản mà chúng ta mong muốn, vậy là được rồi.",
                    Description = "Cuộc sống giống như một bộ phim dài tập, mỗi một tập phim đều có thời gian nhất định vậy nên bạn nhất định không được lãng phí cuộc đời của mình vào những thứ không xứng đáng. Chẳng ai khác ngoài bản thân chúng ta mới là người chịu trách nhiệm cho cuộc sống của mình. Sống trên đời mà luôn phải để ý đến ánh nhìn của người khác, làm cho người khác hài lòng thì thật mệt mỏi.\r\n\r\nKhi cuộc sống ngày một phát triển, nhu cầu của con người cũng tăng cao, chúng ta dần bị cuốn vào các mối quan hệ, công việc, cuộc sống mà quên mất những điều khiến cho cuộc sống của mình thoải mái. Chúng ta luôn sợ ánh nhìn của người khác về mình, bạn rất thích mặc chiếc váy đó nhưng không dám mặc vì sợ người khác sẽ chê bai mình. Bạn rất thích cắt tóc nhưng lại ngại vì thấy kiểu tóc đó nhìn không giống ai. Chúng ta luôn sợ làm người khác buồn, sợ người khác bị tổn thương nhưng lại quên mất bản thân chúng ta cũng cần được yêu thương. Con người không có ai là hoàn hảo cả, bạn không cần cảm thấy có lỗi khi bản thân không được hoàn hảo. Hãy yêu những điều không hoàn hảo đó mới chính là cách tốt nhất để cuộc sống của chúng ta tốt lên mỗi ngày.\r\n\r\nCuộc sống giống như một bộ phim dài tập, mỗi một tập phim đều có thời gian nhất định vậy nên bạn nhất định không được lãng phí cuộc đời của mình vào những thứ không xứng đáng. Chẳng ai khác ngoài bản thân chúng ta mới là người chịu trách nhiệm cho cuộc sống của mình. Sống trên đời mà luôn phải để ý đến ánh nhìn của người khác, làm cho người khác hài lòng thì thật mệt mỏi.\r\n\r\nKhi cuộc sống ngày một phát triển, nhu cầu của con người cũng tăng cao, chúng ta dần bị cuốn vào các mối quan hệ, công việc, cuộc sống mà quên mất những điều khiến cho cuộc sống của mình thoải mái. Chúng ta luôn sợ ánh nhìn của người khác về mình, bạn rất thích mặc chiếc váy đó nhưng không dám mặc vì sợ người khác sẽ chê bai mình. Bạn rất thích cắt tóc nhưng lại ngại vì thấy kiểu tóc đó nhìn không giống ai. Chúng ta luôn sợ làm người khác buồn, sợ người khác bị tổn thương nhưng lại quên mất bản thân chúng ta cũng cần được yêu thương. Con người không có ai là hoàn hảo cả, bạn không cần cảm thấy có lỗi khi bản thân không được hoàn hảo. Hãy yêu những điều không hoàn hảo đó mới chính là cách tốt nhất để cuộc sống của chúng ta tốt lên mỗi ngày.\r\n\r\nSai lầm nhất của chúng ta chính là tưởng rằng khách qua đường là người đi cùng ta đến cuối đoạn đường, giống như những cuộc gặp gỡ không hẹn mà gặp, ngày chia tay chưa chắc chúng ta đã biết trước. Gặp gỡ để chia ly, đôi khi những cuộc chia tay khiến chúng ta không ngừng nghĩ về nó, không ngừng đau lòng thế nhưng định mệnh đã sắp đặt, duyên phận ngắn ngủi thì đành chấp nhận. Cuộc sống vẫn còn ở phía trước, chúng ta rồi sẽ gặp đúng người.\r\n\r\nNội dung của cuốn sách xoay quanh các vấn đề thường gặp trong cuộc sống, tác giả gửi gắm đến độc giả hãy sống cuộc đời của mình, đừng để hoàn cảnh hay bất cứ ai đó mà bạn phải đánh mất chính bản thân mình. Bởi chúng ta là một bản thể đặc biệt và bạn chỉ thật sự hạnh phúc khi sống cuộc đời của chính mình.\r\n\r\nCuộc sống giống như một bộ phim dài tập, mỗi một tập phim đều có thời gian nhất định vậy nên bạn nhất định không được lãng phí cuộc đời của mình vào những thứ không xứng đáng. Chẳng ai khác ngoài bản thân chúng ta mới là người chịu trách nhiệm cho cuộc sống của mình. Sống trên đời mà luôn phải để ý đến ánh nhìn của người khác, làm cho người khác hài lòng thì thật mệt mỏi.\r\n\r\nKhi cuộc sống ngày một phát triển, nhu cầu của con người cũng tăng cao, chúng ta dần bị cuốn vào các mối quan hệ, công việc, cuộc sống mà quên mất những điều khiến cho cuộc sống của mình thoải mái. Chúng ta luôn sợ ánh nhìn của người khác về mình, bạn rất thích mặc chiếc váy đó nhưng không dám mặc vì sợ người khác sẽ chê bai mình. Bạn rất thích cắt tóc nhưng lại ngại vì thấy kiểu tóc đó nhìn không giống ai. Chúng ta luôn sợ làm người khác buồn, sợ người khác bị tổn thương nhưng lại quên mất bản thân chúng ta cũng cần được yêu thương. Con người không có ai là hoàn hảo cả, bạn không cần cảm thấy có lỗi khi bản thân không được hoàn hảo. Hãy yêu những điều không hoàn hảo đó mới chính là cách tốt nhất để cuộc sống của chúng ta tốt lên mỗi ngày.\r\n\r\n",
                    Meta = "Đừng cố làm người tốt trong mắt tất cả mọi người",
                    UrlSlug = "dung-co-lam-nguoi-tot-trong-mat-tat-ca-moi-nguoi",
                    ImageUrl = "https://www.reader.com.vn/uploads/images/dung-co-lam-nguoi-tot-trong-mat-tat-ca-moi-nguoi.jpeg",
                    Published = true,
                    PostedDate = new DateTime(2019, 6, 29, 10, 45, 0),
                    ModifiedDate = null,
                    ViewCount = 780,
                    Author = authors[3],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[17],
                        tags[2],
                        tags[3],
                        tags[12],
                        tags[15]
                    }
                },


                new()
                {
                    Title = "Sách nên đọc: Ba người thấy vĩ đại",
                    ShortDescription = "Có thể nói rằng cuốn sách “Ba người thầy vĩ đại” được rất nhiều bạn đọc yêu thích và chọn đọc bởi thông qua cuốn sách bạn sẽ dần tìm lại bản ngã của chính mình. Chỉ vỏn vẹn 330 trang sách, cuốn sách đã thể hiện trọn vẹn những bài học sâu sắc về cuộc sống, con người, công việc. Với tựa sách là cuốn sách self-help nhưng độc giả sẽ không tìm thấy bất cứ quan điểm trùng lặp nào ở tác phẩm, quan điểm vô cùng mới mẻ và thiết thực. ",
                    Description = "Robin Sharma là một trong những nhà cố vấn được tin cậy nhất thế giới trong việc lãnh đạo cá nhân và tổ chức. Ông xuất thân là một luật sư tranh tụng có tài, sau đó ông chuyển sang viết sách và bước đầu thành công rực rỡ với tựa sách mang tên “The Monk Who Sold His Ferrari”. \r\n\r\nÔng cũng là một trong những tác giả thành công với 9 tựa sách nổi tiếng. Đặc biệt là 2 “bom tấn” The Greatness Guide và The Monk Who Sold His Ferrari xuất bản hàng triệu đầu sách ở khắp 60 nước và được dịch ra hơn 75 ngôn ngữ. Điều đó giúp Robin trở thành tác giả được đọc nhiều nhất trên thế giới.\r\n\r\nTrong đời sống, Robin Sharma dành sự quan tâm sâu sắc đến việc giúp các cựu binh sĩ Mỹ hòa nhập vào cuộc sống thường nhật sau chiến tranh/hoặc thời gian phục vụ quân ngũ. Ông hoạt động tích cực trong việc làm từ thiện giúp trẻ em nghèo nhận ra khả năng lãnh đạo tiềm tàng của chúng thông qua Quỹ Từ Thiện Robin Sharma Dành Cho Trẻ Em.\r\n\r\nMột số tác phẩm tiêu biểu của tác giả được dịch sang tiếng Việt mà bạn có thể tìm đọc như: “Ba người thầy vĩ đại, Đời ngắn ngủi đừng ngủ dài, Nhà lãnh đạo không chức danh”\r\nCái hay nhất của cuốn sách “Ba người thầy vĩ đại” và giúp nó tạo khác biệt so với các cuốn sách self-help khác có lẽ là bởi tác giả không hề đưa ra những quan điểm mang tính giáo điều hay hô hào sáo rỗng mà mọi triết lý đều do người đọc tự cảm nhận thông qua sự đồng hành với anh chàng Jack trên bước đường tìm thấy bản ngã của chính mình.\r\n\r\nThật sự cuốn sách “Ba người thầy vĩ đại” là một trong những cuốn sách đang để gối đầu giường, một tác phẩm xuất sắc về việc thay đổi bản thân để trở nên tốt hơn, những sự tỉnh ngộ sâu sắc bên trong tiềm thức để thật sự thay đổi và hạnh phúc hơn mỗi ngày. Bạn sẽ tìm được những thú vị và bài học giá trị sâu sắc để trở thành phiên bản tốt đẹp nhất và hạnh phúc nhất của chính mình. \r\n\r\nHy vọng bài chia sẻ review sách “Ba người thầy vĩ đại” ở trên đã giúp bạn phần nào hiểu được nội dung và những điều thú vị trước khi tự tay mua chúng và đọc trải nghiệm, giúp bạn có cái nhìn tổng quan nhất về cuốn sách mà không cần mất thời gian tìm kiếm.\r\n",
                    Meta = "Sách nên đọc: Ba người thấy vĩ đại",
                    UrlSlug = "sach-nen-doc-ba-nguoi-thay-vi-dai",
                    ImageUrl = "https://www.reader.com.vn/uploads/images/review-sach-ba-nguoi-thay-vi-dai-2.jpeg",
                    Published = true,
                    PostedDate = new DateTime(2018, 12, 3, 9, 45, 0),
                    ModifiedDate = null,
                    ViewCount = 678,
                    Author = authors[3],
                    Category = categories[7],
                    Tags = new List<Tag>()
                    {
                        tags[0],
                        tags[4],
                        tags[3],
                        tags[9]
                    }
                },

                new()
                {
                    Title = "Hãy khiến tương lai biết ơn vì hiện tại bạn đã cố gắng hết mình",
                    ShortDescription = "Có bao giờ bạn cảm thấy những nỗ lực của mình đều không có kết quả chưa? Có bao giờ bạn cảm thấy thật mông lung, không biết nên tiến hay lùi, tương lai phía trước rất mù mịt chưa? Chắc hẳn không ít thì nhiều, những người trẻ chúng ta đã từng phải trải qua khoảng thời gian tăm tối ấy. Thật ra, mỗi giai đoạn đều có khó khăn nhất định, khó khăn đến để tìm ra được người mạnh mẽ. Và cuốn sách “Hãy khiến tương lai biết ơn vì hiện tại bạn đã cố gắng hết mình” sẽ là người bạn đồng hành trên chặng đường tương lai phía trước, cuốn sách an ủi tinh thần của người trẻ.",
                    Description = "Bạn biết không? Trong cuộc sống này có vô vàn những tình huống có thể khiến con người đang vui vẻ ngay lập tức rơi xuống hố sâu của sự tuyệt vọng. Bạn có thể than vãn cũng có thể khóc lóc nhưng sau đó người phải đi giải quyết khó khăn đó cũng là bạn. Nỗ lực thêm một chút mới có thể thay đổi được mọi thứ.\r\n\r\nChúng ta luôn biết rằng thành công không phải là một cụm từ mà nó còn mang một sức nặng rất lớn, chỉ những ai can đảm, dám đấu tranh, dám làm thì mới mang về cho mình vinh quang. Sách vở có thể đã nói giảm nói tránh cũng có thể nói về thành công một cách nặng nề. Tuy nhiên, bạn có nắm bắt cơ hội để thay đổi được cuộc đời của mình hay không là còn phụ thuộc vào bản thân bạn.\r\n\r\nThỉnh thoảng vì cuộc sống mà đau lòng một chút cũng chẳng sao, cảm thấy ấm ức quá thì có thể khóc một trận thật sướng, sau đó tiếp tục chăm chỉ làm việc. Có những việc chúng ta cảm thấy bản thân thật ngớ ngẩn, tại sao một lỗi nhỏ như vậy cũng có thể sai, bạn không ngừng trách bản thân mình quá vô dụng. Thế nhưng ai cũng có lần đầu tiên, sai có thể sửa chỉ sợ một điều bạn không dám thay đổi.\r\n\r\nNếu đau lòng hãy cho phép bản thân được yếu đuối, nếu mệt mỏi hãy cho phép bản thân được nghỉ ngơi. Bạn xứng đáng được yêu thương và nhiều hơn thế nữa.\r\n\r\nPhàn nàn không chỉ khiến cho bạn hao tâm tổn sức mà còn làm cho mọi chuyện càng tệ đi. Hãy thử nghĩ kĩ lại xem, phàn nàn có thật sự thay đổi được tình thế không? Khi bạn bỏ ra cả một ngày trời chỉ để oán thán cuộc đời, trách móc mọi thứ thì những người khác đã tìm xong cách để vượt qua.\r\n\r\nMỗi một khó khăn đến với bạn đều có ý nghĩa riêng của nó, dù bạn có dùng thái độ như thế nào để đối diện với nó thì người phải giải quyết khó khăn đó cũng là bạn. Vậy nên thay vì than vãn hãy giữ sức để suy nghĩ cách giải quyết vấn đề sẽ tốt hơn.\r\n\r\nPhàn nàn không chỉ khiến cho bạn hao tâm tổn sức mà còn làm cho mọi chuyện càng tệ đi. Hãy thử nghĩ kĩ lại xem, phàn nàn có thật sự thay đổi được tình thế không? Khi bạn bỏ ra cả một ngày trời chỉ để oán thán cuộc đời, trách móc mọi thứ thì những người khác đã tìm xong cách để vượt qua.\r\n\r\nMỗi một khó khăn đến với bạn đều có ý nghĩa riêng của nó, dù bạn có dùng thái độ như thế nào để đối diện với nó thì người phải giải quyết khó khăn đó cũng là bạn. Vậy nên thay vì than vãn hãy giữ sức để suy nghĩ cách giải quyết vấn đề sẽ tốt hơn.\r\n\r\nPhàn nàn không chỉ khiến cho bạn hao tâm tổn sức mà còn làm cho mọi chuyện càng tệ đi. Hãy thử nghĩ kĩ lại xem, phàn nàn có thật sự thay đổi được tình thế không? Khi bạn bỏ ra cả một ngày trời chỉ để oán thán cuộc đời, trách móc mọi thứ thì những người khác đã tìm xong cách để vượt qua.\r\n\r\nMỗi một khó khăn đến với bạn đều có ý nghĩa riêng của nó, dù bạn có dùng thái độ như thế nào để đối diện với nó thì người phải giải quyết khó khăn đó cũng là bạn. Vậy nên thay vì than vãn hãy giữ sức để suy nghĩ cách giải quyết vấn đề sẽ tốt hơn.\r\n\r\nPhàn nàn không chỉ khiến cho bạn hao tâm tổn sức mà còn làm cho mọi chuyện càng tệ đi. Hãy thử nghĩ kĩ lại xem, phàn nàn có thật sự thay đổi được tình thế không? Khi bạn bỏ ra cả một ngày trời chỉ để oán thán cuộc đời, trách móc mọi thứ thì những người khác đã tìm xong cách để vượt qua.\r\n\r\nMỗi một khó khăn đến với bạn đều có ý nghĩa riêng của nó, dù bạn có dùng thái độ như thế nào để đối diện với nó thì người phải giải quyết khó khăn đó cũng là bạn. Vậy nên thay vì than vãn hãy giữ sức để suy nghĩ cách giải quyết vấn đề sẽ tốt hơn.\r\n",
                    Meta = "Hãy khiến tương lai biết ơn vì hiện tại bạn đã cố gắng hết mình",
                    UrlSlug = "hay-khien-tuong-lai-biet-on-vi-hien-tai-ban-da-co-gang-het-minh",
                    ImageUrl = "https://www.reader.com.vn/uploads/images/hay-khien-tuong-lai-biet-on-vi-hien-tai-ban-da-co-gang-het-minh.jpeg",
                    Published = true,
                    PostedDate = new DateTime(2018, 5, 3, 10, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 176,
                    Author = authors[4],
                    Category = categories[7],
                    Tags = new List<Tag>()
                    {
                        tags[1],
                        tags[8],
                        tags[9]
                    }
                },

                new()
                {
                    Title = "Gửi bạn người đã kiệt sức vì những chịu đựng âm thầm",
                    ShortDescription = "Nếu bạn đang bị kiệt sức giữa ngã ba đường của tuổi trẻ, vậy thì hãy để cuốn sách “Gửi bạn người đã kiệt sức vì những chịu đựng âm thầm” sẽ dẫn đường giúp bạn. Những nỗi buồn hay khổ đau mà bạn đang nếm chịu rồi sẽ được xoa dịu, hãy lật mở từng trang sách để cùng khám phá nội dung thú vị của nó nhé!",
                    Description = "Với phong cách viết gần gũi, nhẹ nhàng nhưng lại chứa đựng nhiều bài học sâu sắc Gửi bạn, nguời đã kiệt sức vì âm thầm chịu đựng sẽ mang đến cho độc giả những bài học thật ý nghĩa, giúp bạn vượt qua khó khăn, dịu dàng an ủi những vết thương của người trưởng thành. Và hơn hết nữa, cuốn sách giúp bạn trở thành phiên bản của chính mình.\r\n\r\nLớn lên rồi chúng ta mới nhận ra cuộc sống vô cùng khắc nghiệt, đi làm rồi mọi thứ còn khó khăn hơn. Bạn cô đơn với những nỗi niềm không biết tâm sự cùng ai, lúc này bạn rất muốn quay lại tuổi thơ, tiếc là thời gian trôi đi sẽ không bao giờ trở lại. Con đường phía trước chỉ có một mình bạn đi, dù giông bão thế nào rồi thành công cũng sẽ đến thôi. Bạn cảm thấy mệt mỏi, ủ rủ không có tinh thần hay vui vẻ đón nhận thì mọi thứ sẽ đến đúng hẹn. Thế nên đừng lúc nào cũng oán trách cuộc đời hãy tập làm quen với hiện tại, khó khăn rồi cũng sẽ qua, hạnh phúc đang đợi bạn ở phía cuối con đường.\r\n\r\nCó bao giờ sau một ngày dài mệt mỏi đến việc cầm điện thoại lên xem tin nhắn bạn cũng không muốn làm không? “Mệt mỏi, kiệt sức” không chỉ là cảm xúc mà nó còn là thể chất vậy nên tôi không hy vọng bạn làm việc đến quên mất phải nghỉ ngơi. Nếu cảm thấy mọi thứ quá sức chịu đựng hãy để bản thân được khóc, sau đó đừng quên rằng bạn phải tiếp tục đứng dậy và cố gắng.\r\n\r\nChúng ta đều đã trưởng thành vì thế không phải lúc nào cũng có thể mang những mệt mỏi của mình đổ lên đầu mọi người. Bạn vẫn âm thầm chịu đựng, vẫn âm thầm nỗ lực từng ngày, hãy nhớ rằng bất cứ ai trong chúng ta cũng đều có khả năng tự giải tỏa cảm xúc của mình. Thế nhưng đừng tự mình ôm quá nhiều nỗi buồn, nếu một lúc nào đó cảm thấy quá mệt mỏi hãy mang nó chia sẻ với người mà bạn tin tưởng nhất, biết đâu nói ra lại tốt hơn là giữ trong lòng.\r\n\r\nSẽ có một vài khoảnh khắc trong cuộc đời bạn cảm thấy bản thân thật yếu đuối hoặc bạn chẳng còn thiết tha gì với ước mơ, cuộc sống ở ngoài kia. Bạn cảm thấy mình thật chật vật để sống qua ngày, những lúc như vậy đừng tự trách bản thân, bạn đã kiệt sức như vậy rồi. Lúc này bạn cần nghỉ ngơi để lấy lại năng lượng. Đừng tự đổ lỗi cho bản thân, bạn không có lỗi, bạn chỉ là cố gắng nhiều quá nên bạn đang bị mất năng lượng. Bạn cần thời gian để nạp năng lượng, vì vậy hãy yêu thương bản thân thật nhiều bằng cách nghỉ ngơi bạn nhé!\r\n\r\nTôi mong bạn sẽ có đủ dũng khí để một mình. Và nếu bạn đang mông lung và thật sự mỏi mệt. Hy vọng câu chuyện về sự thành khẩn của chính tôi trong quyển sách này sẽ trở thành một niềm an ủi đối với bạn. Dành cho bạn, người đêm nay thây rũ rượi hoặc chẳng yêu thích bất cứ điều gì.\r\n\r\nHôm nay cũng với một lòng muốn làm tốt, kiên cường trải qua một ngày dài. Bạn đã vất vả rồi.\r\n",
                    Meta = "Gửi bạn người đã kiệt sức vì những chịu đựng âm thầm",
                    UrlSlug = "gui-ban-nguoi-da-kiet-suc-vi-nhung-chiu-dung-am-tham",
                    ImageUrl = "https://www.reader.com.vn/uploads/images/gui-ban-nguoi-da-kiet-suc-vi-nhung-chiu-dung-am-tham-1.jpeg",
                    Published = true,
                    PostedDate = new DateTime(2019, 5, 5, 13, 55, 0),
                    ModifiedDate = null,
                    ViewCount = 510,
                    Author = authors[4],
                    Category = categories[7],
                    Tags = new List<Tag>()
                    {
                        tags[4],
                        tags[7],
                        tags[6]
                    }
                },

                //================================================10

                new()
                {
                    Title = "Sách hay về hôn nhân gia đình: Bí quyết giữ lửa hạnh phúc trọn vẹn",
                    ShortDescription = "Với phong cách viết gần gũi, nhẹ nhàng nhưng lại chứa đựng nhiều bài học sâu sắc Gửi bạn, nguời đã kiệt sức vì âm thầm chịu đựng sẽ mang đến cho độc giả những bài học thật ý nghĩa, giúp bạn vượt qua khó khăn, dịu dàng an ủi những vết thương của người trưởng thành. Và hơn hết nữa, cuốn sách giúp bạn trở thành phiên bản của chính mình.",
                    Description = "“7 Bí quyết giúp hôn nhân hạnh phúc” được hai tác giả John M Gottman và Nano Silver trình bày với các nội dung dễ hiểu, bạn có thể dễ dàng học hỏi và đưa vào chính cuộc hôn nhân của mình để giúp tình cảm vợ chồng thêm bền chặt theo thời gian. Bạn nên dựa vào tình cảnh của gia đình mình đã biết cách áp dụng các bí quyết sao cho thật phù hợp nhất. Gia đình luôn là nơi bình yên nhất, chẳng nơi đâu bằng Nhà bởi vậy hãy luôn trân trọng khi bạn có một gia đình luôn yêu thương và là hậu phương vững chắc cho bạn. \r\n\r\nCuốn sách với hơn 100 quy tắc dành cho các cặp vợ chồng, những quy tắc rất đơn giản và gần gũi mà các cặp đôi có thể dễ dàng áp dụng để hiểu và vun đắp hạnh phúc gia đình cùng nhau. Không ai có thể hợp nhau hoàn toàn, nhưng đã quyết định nắm tay nhau đi đến cuối cuộc đời thì hãy học cách để cảm thông và thấu hiểu nhau. \r\n\r\nĐời sống hôn nhân gia đình, chuyện vợ chồng xích mích sẽ khó tránh khỏi, nhưng chính các tác giả của cuốn sách này đã dựa trên kinh nghiệm của bản thân về hôn nhân để đưa ra những lời khuyên và quy tắc rất chân tình và thực tế. Từ việc ứng xử giữa hai vợ chồng, cách giáo dục con cái, cách giao tiếp giữa hai bên nội ngoại cho đến vấn đề tình dục của cả hai cũng được đề cập một cách thẳng thắn và chân thành nhất. \r\n\r\nNhiều cặp vợ chồng trẻ trước khi kết hôn sẽ có suy nghĩ không biết cuộc sống hôn nhân của mình sau kết hôn sẽ ra sao? Đừng lo cuốn sách “Hôn nhân chân kinh - Đọc kỹ trước khi kết hôn” sẽ giúp bạn trả lời được những câu hỏi lo lắng đó. Cuốn sách sẽ không hướng dẫn cho bạn cách làm thế nào để tổ chức một lễ cưới hoành tráng hay lộng lẫy nhất mà sẽ giúp bạn sở hữu được cách để giữ cho cuộc hôn nhân của mình lúc nào cũng bền lâu và hạnh phúc nhất. \r\n\r\nTác giả cuốn sách là John Gray, ông là một chuyên gia tư vấn hạnh phúc hôn nhân gia đình cho các cặp đôi với hơn 28 kinh nghiệm, bởi vậy cuốn sách chính là kinh nghiệm được đúc kết từ bản thân gửi đến bạn đọc. \r\n\r\nTác giả đã đưa ra rất nhiều lời khuyên hữu ích dành cho các cặp vợ chồng trong cách ứng xử, nuôi dạy con cái sau cho phù hợp nhất nhưng vẫn giữ được mối quan hệ tình cảm thắm thiết giữa các thành viên trong gia đình. \r\n\r\nVới top sách hay về hôn nhân gia đình kể trên, hy vọng đã giúp các cặp đôi có thêm kinh nghiệm sống để biết yêu thương, trân trọng những gì mình đang có và vun đắp cho tình cảm thêm mặn nồng. Vợ chồng là chuyện trăm năm, hãy luôn vui sống, trân trọng và biết ơn vì luôn có gia đình yêu thương bên cạnh bạn nhé!\r\n",
                    Meta = "Sách hay về hôn nhân gia đình: Bí quyết giữ lửa hạnh phúc trọn vẹn",
                    UrlSlug = "sach-hay-ve-hon-nhan-gia-dinh-bi-quyet-giu-lua-hanh-phuc-tron-ven",
                    ImageUrl = "https://www.reader.com.vn/uploads/images/sach-dan-ong-sao-hoa-dan-ba-sao-kim.jpeg",
                    Published = true,
                    PostedDate = new DateTime(2019, 10, 30, 12, 45, 0),
                    ModifiedDate = null,
                    ViewCount = 296,
                    Author = authors[6],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[3],
                        tags[4],
                        tags[9],
                        tags[15]
                    }
                },

                new()
                {
                    Title = "Đại dương đen: Ánh sáng giữa đại dương tăm tối",
                    ShortDescription = "Tiếp nối thành công từ những cuốn sách trước đó như “Bức xúc không làm ta vô can”, “Thiện – ác và smartphone”, “Tìm mình trong thế giới hậu tuổi thơ”, Tiến sĩ Đặng Hoàng Giang công bố cuốn sách mang tên “Đại dương đen” – kết tinh hành trình đầy nhọc nhằn và nhẫn nại của tác giả với người trầm cảm trong suốt hai năm ròng.",
                    Description = "Cuốn sách trước hết ghi lại những trải nghiệm thực tế của những người mắc bệnh trầm cảm, cách họ sống và làm việc, yêu đương và cống hiến với căn bệnh quái ác nhưng thiếu sự hiểu biết và đồng cảm từ người thân, gia đình, xã hội. Nhân vật chính trong những câu chuyện không bó hẹp với bất cứ ai ở bất kì giới tính, độ tuổi; nghề nghiệp hay địa vị xã hội. \r\n\r\nNhư tác giả Đặng Hoàng Giang đã tóm tắt: “Nó không chỉ có ở trong giới trẻ, “vì chúng vốn thất thường trong cảm xúc.” Không chỉ ở trong giới văn nghệ sĩ, “vì họ quá nhạy cảm”. Không chỉ ở người có kinh tế đầy đủ, “bởi người nghèo lo kiếm sống thì lấy đâu ra thời gian mà trầm cảm”. Trầm cảm phổ biến như thế nào? Nếu bạn có 1000 người bạn Facebook, thì trong năm qua, bảy mươi người trong số đó mắc trầm cảm.”\r\n\r\nTừng câu từng chữ như đan bện vào nhau tạo ra bức màn tăm tối ngăn cách những bệnh nhân trầm cảm được sống, được cống hiến, được yêu thương và hạnh phúc. Những câu chuyện u ám, ảm đạm, ngạt thở, dữ dội, không lối thoát có thể sẽ gây kích động tâm lí cho người đọc.\r\n\r\nTa được gặp Uyên, 21 tuổi, sinh viên ngành Kinh tế và cách đối chọi với căn bệnh đầy cực đoan: tự làm đau cơ thể. Ham muốn làm đau bản thân dữ dội và thường trực, Uyên luôn thuyết phục bạn bè “đưa cho mình vật gì nhọn để tự hại”. Chỉ khi đó, Uyên mới có thể “trở lại bình thường và sự căng thẳng dịu xuống”.\r\n\r\nHay người mẹ mới sinh bị cô lập trong sự ghẻ lạnh, thờ ơ của cả gia đình bố mẹ đẻ và gia đình nhà chồng đến độ có những suy nghĩ làm hại chính đứa con mình sinh ra: “Tôi biết là mình đang bị trầm cảm. Đây không phải là lần đầu tôi muốn làm cho H đau. Tôi yêu nó vô cùng, tôi đã suýt mất mạng khi sinh nó ra, nhưng tôi vẫn có cảm giác muốn đày đọa nó.”\r\n\r\nCăn bệnh trầm cảm dường như cũng “lây lan” như dịch bệnh, căn bệnh mà mầm mống của nó dường như không thể bị dập tắt. Đời ông/bà, đời cha/mẹ, đời con, đời cháu,… cứ thế duy trì những bất ổn trong tinh thần. Rồi từ một thành viên trong gia đình, trầm cảm hủy hoại cuộc sống của tất cả những người xung quanh. Tựa như một giọt dầu loang trên mặt nước, trầm cảm cứ thế nuốt chửng lấy những ánh sáng thoi thóp của ngày tàn: \r\n\r\nThành, 29 tuổi, là một nhân viên văn phòng, anh chống chọi với căn bệnh trầm cảm trong nhiều năm. Có lẽ nhiều người không thể hiểu được cảm giác mà Thành và gia đình phải chịu đựng. Khi đi tìm nguồn cơn của căn bệnh, Thành nhận ra căn bệnh đang giày vò anh hàng ngày hàng giờ đã từng giày vò ông, cha mình. \r\n\r\nThành nhớ về những gì được biết về người ông. Bố Thành như bản sao của ông nội và Thành cũng đau đớn nhận ra, anh là người lưu giữ “vật chất di truyền” đầy trái ngang ấy. Không chỉ ông nội và cha, Thành cũng có một người mẹ chịu nhiều thương tổn, chỉ khác là mẹ của Thành có lẽ chưa phải một người trầm cảm hay có các vấn đề về tâm thần khác.\r\n\r\nTrầm cảm không phải bẩm sinh, những nạn nhân trầm cảm cũng không đối diện với nó theo một mô thức giống nhau. Nhưng kì lạ thay, giữa những con người có những phản ứng trái chiều đối với tổn thương trong quá khứ lại nảy sinh sự hòa hợp đầy “bạo lực và phá hủy”. Bố Thành đập phá cửa nhà, mẹ Thành làm như không rồi hàn gắn những đổ vỡ. Bố Thành “điên loạn”, phá phách, mẹ Thành nhẫn nhục, chịu đựng. Nỗi đau của bệnh nhân trầm cảm là một, nỗi đau của những người thân, gia đình và xã hội là mười. \r\n\r\nNhững đoạn văn đầy tăm tối có thể khiến bạn đọc bị kích động mạnh. Nhưng có lẽ, đó là cách duy nhất để mỗi chúng ta có cái nhìn thực tế, khách quan, toàn diện hơn về thế giới của người trầm cảm. Tác giả làm tất cả điều đó với mong muốn kêu gọi mọi người có cái nhìn chân thật, có sự đồng cảm với hoàn cảnh của họ. \r\n",
                    Meta = "Đại dương đen: Ánh sáng giữa đại dương tăm tối",
                    UrlSlug = "dai-duong-den-anh-sang-giua-dai-duong-tam-toi",
                    ImageUrl = "https://reviewsach.net/wp-content/uploads/2022/03/reviewsach.net-dai-duong-den-by-dang-hoang-giang-840x840.jpeg",
                    Published = true,
                    PostedDate = new DateTime(2020, 8, 15, 1, 4, 0),
                    ModifiedDate = null,
                    ViewCount = 185,
                    Author = authors[17],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[0],
                        tags[3],
                        tags[17]
                    }
                },

                new()
                {
                    Title = "Nhật ký Covid và những chuyện chưa kể",
                    ShortDescription = "Không quá xuất sắc để tạo nên một cú hit nhưng nội dung vừa đủ, “Nhật ký Covid và những chuyện chưa kể” của bác sĩ Ngô Đức Hùng mang đến một lượng tri thức vừa tầm giúp người đọc hiểu thêm về dịch bệnh để bớt hoang mang, đồng thời truyền tải thông điệp về sự tử tế và sức mạnh cộng đồng giữa đại dịch.",
                    Description = "Bình thường, vì đây đúng là một cuốn nhật ký, chính là thể loại văn xuôi ghi chép sinh hoạt thường ngày và cảm xúc riêng tư của một người, thậm chí có cả những bức thư tình, số một, số hai, rồi số ba. Vì là nhật ký, nên có đôi ba chương cũng tản mạn những việc khá lan man, nhưng đa phần vẫn xoay quanh vấn đề dịch bệnh.\r\n\r\nBất thường, vì người viết là một bác sĩ, càng bất thường hơn khi đặt trong bối cảnh cả thế giới đang hứng chịu một thảm họa khủng khiếp đã lấy đi mạng sống của hàng triệu người, con số vẫn không ngừng gia tăng. Cuốn nhật ký bởi vậy giống như một biên niên ngắn gọn về hai năm Covid-19 của thế giới và Việt Nam, tính từ giai đoạn cuối năm 2019 đến tháng 4 năm 2021, dưới góc nhìn của một bác sĩ trực tiếp tham gia chống dịch từ những ngày đầu.\r\n\r\n“Nhật ký Covid và những chuyện chưa kể” gồm 5 phần với nhiều chương nhỏ. “Mở đầu” với những sự kiện, dự báo về Covid-19, lúc này vẫn còn là một con virus chưa được đặt tên chính thức và là nguồn cơn hoang mang lớn đối với y học thế giới. Phần hai – “Năm Covid thứ nhất” ghi lại những câu chuyện ngay tâm dịch bệnh viện Bạch Mai khi bị phong tỏa lần đầu tiên và tác giả đã xung phong đi vào giữa chiến tuyến. Phần ba – “Tháng ngày bình yên” là một nhịp thở chậm khi cả xã hội giãn cách, tác giả đứng bên lề cuộc đời “nhìn ngắm thiên hạ cãi nhau, yêu và sống”, trước những diễn biến cùng thay đổi chưa từng có trong lịch sử. Phần bốn – “Năm Covid thứ hai” đưa độc giả quay trở lại giữa tâm dịch một lần nữa ở những chiến tuyến khác nhau. Phần “Kết” là một dấu lặng, với nỗ lực cứu chữa một bác già có bệnh lý nền nặng, nguy cơ tử vong cao, không may bị lây Covid, hòng cứu bác khỏi con virus quái ác, để được trở về nhà và ra đi thanh thản hơn trong vòng tay gia đình. Thật may mắn, nỗ lực ấy đã được đền đáp.\r\n\r\nVăn phong có phần “lành tính” hơn tác phẩm đầu tay “Để yên cho bác sĩ hiền”, dẫu đôi lúc vẫn đanh đá khi cần, nhưng cả cuốn sách là giọng trần thuật hiện thực một cách chân thực của người bác sĩ trực tiếp cứu chữa, chứng kiến và thấu hiểu giá trị của sinh mạng.\r\n\r\nTừ buổi sơ khai đã tồn tại một dạng vật chất di truyền chưa thể gọi là dạng sống hoàn toàn, đó là virus. Với cấu tạo chỉ gồm lớp vỏ bọc xung quanh đoạn mã gen di truyền, virus sống nhờ lén lút bám vào tế bào vật chủ. Bất cứ nơi nào có sự sống, ở đó tồn tại virus. Covid chỉ là một chủng nhỏ bé trong hàng triệu loại virus trong tự nhiên.\r\n\r\nVirus có lợi thế về số lượng gen ít, từ vài đến vài trăm, giúp chúng đột biến nhanh hơn, chỉ vài tuần có thể tạo ra biến thể mới. Con người có bộ gen hết sức phức tạp, xấp xỉ 20.000, muốn có một đặc tính tốt từ chọn lọc tự nhiên phải vất vả chọn lọc cả nghìn năm. Năng lực loài người cũng hạn chế, mất 10 năm để thế giới tìm ra được một thuốc kháng sinh mới, còn virus chỉ mất 2 – 3 năm để thuốc này không còn tác dụng. Đó là lý do các nhà khoa học tìm mọi cách để viễn cảnh diệt chủng không xảy ra. Qua những bài học dịch bệnh khủng khiếp trong quá khứ, vaccine trở thành phương án cứu trợ duy nhất cho đến lúc này.\r\n\r\n\r\n“Nhật ký Covid” ghi lại chi tiết thông tin từ những ngày đầu khi Covid bất thình lình xuất hiện và đánh úp nhân loại, đến những giải mã đầu tiên và sự thay đổi trong phác đồ điều trị.\r\n\r\nĐiều đáng sợ của Covid là trong những ca dương tính, có những ca không có triệu chứng gì, cứ diễn ra âm thầm cho đến khi tổn thương phổi lan rộng đủ lớn thì lăn đùng ra suy hô hấp.\r\n\r\nBác sĩ Ngô Đức Hùng chia sẻ:\r\n\r\n“Đứng giữa cả rừng bệnh nhân Covid tìm xem ai sẽ nặng lên cũng giống như bới trong đàn hổ tìm con nào màu vàng có vằn đen lẫn trong đám màu đen có vằn vàng vậy. Bởi sự hiểu biết về các đặc điểm sinh học của con virus này vẫn còn hạn chế nên cơ bản việc dự báo gần như vô kế khả thi, chỉ còn cách theo dõi liên tục bằng xét nghiệm và hình ảnh chụp chiếc mà thôi. Những thứ này cũng chỉ mang tính tương đối, bởi nó còn phụ thuộc vào khả năng bù trừ khác nhau của mỗi người. Có bệnh nhân triệu chứng rầm rộ nhưng phổi tổn thương không nhiều. Lại có hôm cả đội chạy nháo nhào toát mồ hôi sau khi nhìn thấy cái phổi trắng xóa, chắc mẩm lôi ngay lên hồi sức nằm, ra đến nơi thấy thằng bé vẫn đùa như giặc.”\r\n\r\nCó thể thấy rõ rằng để theo dõi liên tục bệnh nhân Covid trong quá trình điều trị, cần nhân lực và vật lực rất lớn. Y tế quá tải là một tình trạng hết sức đáng sợ. Không nên để ngành y đơn độc trong cuộc chiến này.\r\n\r\nĐứng trước dịch bệnh, nhất là từ một con virus còn nhiều ẩn số như Covid-19, mọi người trở nên hoang mang sợ hãi là điều khó tránh khỏi. Tuy nhiên, không nên kỳ thị người bệnh, nhân viên y tế và những người trực tiếp tham gia chống dịch.\r\n\r\nThay vì bấn loạn, hãy trân quý những điều bình dị bé nhỏ, bình yên cùng chống dịch và làm theo các chỉ dẫn của cơ quan chức năng.\r\n\r\n\r\nCuốn sách như một bộ phim sinh động quay lại nhiều cảnh đời khác nhau trong hai năm dịch bệnh. Điểm sáng vẫn là tình người giữa tao đoạn khó khăn này, giá trị ấy là một hiện thực luôn được khẳng định và làm giàu thêm.\r\n",
                    Meta = "Nhật ký Covid và những chuyện chưa kể",
                    UrlSlug = "nhat-ky-covid-va-nhung-chuyen-chua-ke",
                    ImageUrl = "https://reviewsach.net/wp-content/uploads/2021/12/Nhat-ky-Covid-va-nhung-chuyen-chua-ke-Reviewsachnet-840x840.jpg",
                    Published = true,
                    PostedDate = new DateTime(2019, 7, 3, 2, 45, 0),
                    ModifiedDate = null,
                    ViewCount = 1053,
                    Author = authors[10],
                    Category = categories[7],
                    Tags = new List<Tag>()
                    {
                        tags[2],
                        tags[7],
                        tags[6]
                    }
                },

                new()
                {
                    Title = "Tâm lý học tội phạm phác họa chân dung kẻ phạm tội",
                    ShortDescription = "Được viết bởi Diệp Hồng Vũ – một nhà tâm lý học, nhà văn nổi tiếng về khoa học tâm lý. Ông đã sử dụng 36 vụ án kinh điển của FBI cho chúng ta có cái nhìn cụ thể nhất về tâm lý của kẻ phạm tội cũng như những kiến thức xung quanh phương pháp phác họa chân dung tội phạm.",
                    Description = "Hiện nay, ngành tâm lý học nói chung và tâm lý học tội phạm nói riêng đã và đang được biết đến nhiều hơn. Qua những bộ phim hay bộ truyện trinh thám nổi tiếng có áp dụng việc phân tích tâm lý tội phạm qua hiện tường, tang vật để phá án. Tuy nhiên, phương pháp này đang được siêu nhiên hóa do chưa có lời giải thích kĩ càng từ các chuyên gia. Vì thế cuốn sách này sẽ cung cấp một cái nhìn cận cảnh về phương pháp cũng như sự kết hợp của nhiều yếu tố khác nhau trong mỗi vú án. Cuối mỗi câu chuyện sẽ có mục “chia sẻ của chuyên gia tâm lý tội phạm” đưa đến những kiến thức xoay quanh lĩnh vực phá án, điều tra, hồ sơ phạm tội và tâm lý những kẻ phạm tội, từ đó đưa ra những giải đáp về quá trình để phá được một vụ án. Ngoài ra, độc giả có thể rèn luyện sự tư duy của mình qua những vụ án, thử sức với việc phân tích từ hiện trường, tang vật, nhân chứng của vụ án đến mạch suy nghĩ của tội phạm qua sự dẫn dắt đầy lôi cuốn của Diệp Hồng Vũ.\r\n\r\nCách kể ngắn gọn, đi thẳng vào vấn đề và chân thực về mỗi vụ án. Từ ngữ được lựa chọn kỹ càng giúp phần nào giảm đi sự đáng sợ, rùng rợn nhưng vẫn giữ được chất riêng của những bản án. Cấp độ man rợ của những vụ án sẽ càng nâng lên theo từng trang sách. Đơn giản chỉ là những vụ án trả thù, lừa lọc tiền của hay phục vụ mục đích tình dục dần dần sẽ trở thành những cuộc thảm sát, giết người hàng loạt với số nạn nhân lên đến hơn 100 người. Kinh khủng hơn cả có những thủ ác vẫn chưa lộ diện dù đã trải qua cả thập kỷ, cô bé 14 tuổi mang gương mặt ngây thơ nhưng lại chính là thủ phạm đằng sau 3 mạng người đến cả người mẹ sẵn sàng giết chết đứa con của mình rồi ngụy trang thành một vụ bắt cóc. Nhưng đến cuối cùng nhờ sự nỗ lực của cảnh sát kết hợp với các bài kiểm tra nói dối của FBI, những chuyên gia tâm lý, sĩ quan họ đã đem tội ác đó phơi bày ra ánh sáng, làm những sát nhân đó phải đứng trước vành móng ngựa.\r\n\r\nCó thể nói, sau mỗi vụ án chúng ta không những rút ra được những kiến thức xoay quanh tâm lí học mà còn là cách đối nhân xử thế, biết được hậu quả đằng sau những hành động chúng ta coi là vô tình hay nhỏ bé.\r\n\r\nDiệp Hồng Vũ đã đưa đến cho người đọc đi qua từ những luồng cảm xúc sợ hãi, hoang mang đến bất bình, tức giận và rồi cuối cùng ông đưa đến sự tiếc hận, thương cảm đan xen với sự căm ghét cho độc giả chỉ qua vài dòng kể lại quá khứ đầy đau đớn hay ý nghĩ man rợ trong suy nghĩ của những tội phạm ấy. Những từ ngữ đều không quá chuyên ngành kết hợp với sự uyển chuyển trong việc miêu tả lại quá khứ của thủ phạm làm sẽ độc giả không thể rời mắt khỏi trang sách.\r\n\r\nTừ ngữ lôi cuốn và cách dẫn dắt đầy lôi cuốn của Diệp Hồng Vũ, độc giả sẽ được cuốn vào một thế giới riêng mang màu sắc u tối của 36 vụ án gay cấn. Đọc xong nhiều người sẽ cảm thấy có chú tiếc nuối, hụt hẫng vì 36 vụ án có lẽ như chưa thỏa mãn được họ. 279 trang sách cung cấp cho người đọc không chỉ những giây phút tò mò căng thẳng mà cả những kiến thức chung nhất về phương pháp phác họa tâm lý học tội phạm.\r\n\r\nCó thể nói đây chính là tác phẩm gây ấn tượng nhất của Hồng Vũ, qua cuốn sách này, ông đã thể hiện được kiến thức và hiểu biết sâu rộng của bản thân. Đối với những ai là tín đồ của sách, truyện trinh thám hay có sở thích suy luận, muốn đặt mình vào người điều tra để tư duy khám ra ra sự thật đằng sau những vụ án vậy “ tâm lý học tội phạm-phác họa chân dung kẻ phạm tội” chính là cuốn sách dành cho bạn.\r\n",
                    Meta = "Tâm lý học tội phạm phác họa chân dung kẻ phạm tội",
                    UrlSlug = "tam-ly-hoc-toi-pham-phac-hoa-chan-dung-ke-pham-toi",
                    ImageUrl = "https://reviewsach.net/wp-content/uploads/2021/12/reviewsach.net-tam-ly-hoc-toi-pham.jpg",
                    Published = true,
                    PostedDate = new DateTime(2019, 3, 16, 3, 45, 0),
                    ModifiedDate = null,
                    ViewCount = 690,
                    Author = authors[14],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[0],
                        tags[8],
                        tags[4],
                    }
                },

                new()
                {
                    Title = "Ngọn lửa xanh – Tự truyện đầu tiên Yuzuru Hanyu",
                    ShortDescription = "Yuzuru Hanyu được xem là nam vận động viên trượt băng nghệ thuật vĩ đại nhất mọi thời đại, người thiết lập 19 kỷ lục thế giới về điểm số và sở hữu đủ bộ huy chương vàng của các giải đấu quốc tế quan trọng nhất tính từ cấp độ Thiếu niên đến cấp độ Trưởng thành. “Ngọn lửa xanh” là cuốn tự truyện đầu tiên của Yuzu được hoàn thành và ra mắt vào năm 2012. Đó là một chặng đường gặp gỡ và từng bước chinh phục bộ môn trượt băng nghệ thuật của một ý chí phi thường.",
                    Description = "Yuzuru Hanyu sinh ngày 07/12/1994 tại Sendai, Nhật Bản. Cái tên “Yuzuru” mang hàm nghĩa một sợi dây cung được kéo căng – tượng trưng cho sự tự tin, sức mạnh và lòng ngay thẳng – gửi gắm niềm hy vọng của bố mẹ rằng con trai họ sẽ kiên cường trước những thăng trầm cuộc sống.\r\n\r\n“Ngọn lửa xanh” là những chia sẻ chân thành của Yuzu khi nhìn lại hành trình trưởng thành từ lúc còn là cậu bé đầu nấm quần yếm lần đầu gặp gỡ trượt băng nghệ thuật đến cậu học sinh lớp 11 lần đầu tiên giành được tư cách đại diện Nhật Bản tham dự giải Vô địch Thế giới.\r\n\r\nYuzu bắt đầu trượt băng khi mới 4 tuổi, vẫn chỉ là một cậu bé mải mê theo đuôi chị gái, trượt băng cũng là học cùng với chị. Dạo ấy, hình ảnh Yuzu bé nhỏ đội mũ bảo hiểm trượt băng và ngã đập đầu xuống sân băng trở nên quen thuộc. Lúc đầu Yuzu thích các giải đấu – nơi nhiều khán giả ngắm nhìn mình biểu diễn, nhưng lại ghét việc luyện tập bởi nó quá khổ sở, quá nặng nề. Trong khi bạn bè vui chơi sau giờ học, chỉ có mình Yuzu phải luyện tập. Thế nhưng đứng trước hai sự lựa chọn từ bỏ hay tiếp tục, Yuzu bé nhỏ vẫn chọn kiên trì và cố gắng nhiều hơn.\r\n\r\nSau cuộc gặp gỡ với trượt băng nghệ thuật cùng những câu chuyện thuở bé mang theo niềm vui và nỗi buồn rất đỗi đáng yêu, việc xác định niềm đam mê cả đời với bộ môn trượt băng nghệ thuật của Yuzu 10 tuổi đã chứng tỏ tâm tính trưởng thành và ý chí kiên định của một vận động viên trượt băng nghệ thuật đầy triển vọng.\r\n\r\nĐộc giả hăm hở dõi theo dặm đường khổ luyện và từng bước chinh phục trong sự nghiệp thi đấu của Yuzu xuyên suốt những chương sách còn lại: trở thành nhà vô địch 15 tuổi của giải Thiếu niên Thế giới, tiếp tục thách thức ở cấp độ Trưởng thành, ngày 11 tháng 3, trận quyết tử tại chuỗi giải đấu Grand Prix, giải Chung kết Grand Prix và Vô địch Quốc gia, hướng tới giải Vô địch Thế giới và Thế vận hội.\r\n\r\nNgày 11 tháng 3 có sự kiện gì?\r\n\r\nVào ngày 11/03/2011, trận đại thảm hoạ động đất sóng thần miền Đông Bắc Nhật Bản cướp đi gần 20000 mạng người xảy ra tại khu vực Tohoku, và Sendai là một trong những nơi chịu ảnh hưởng nặng nề nhất. Yuzu đang ở trên sân băng lúc động đất xảy ra và phải đi sơ tán cùng với đôi giày trượt trên chân.\r\n\r\n“Đến tận bây giờ, khi nhắm mắt lại, em vẫn hồi tưởng được rất nhiều điều: cảm giác mặt băng rung lên, chấn động đẩy mặt đất cuộn lên cao, nỗi sợ hãi khi chân em tự di chuyển… Em vẫn còn nhớ như in toàn bộ khoảnh khắc lúc sân băng bị phá hủy.”\r\n\r\nĐó là đại thảm họa kinh hoàng! Sau trận thảm họa kép, Yuzu làm việc với một số tổ chức từ thiện để hỗ trợ quá trình khắc phụ hậu quả thiên tai. Cùng với các vận động viên trượt băng khác, Yuzu tham gia biểu diễn tại nhiều sự kiện để gây quỹ cho các nạn nhân gặp khó khăn. Yuzu cũng quyết định bán đấu giá đồ đạc cá nhân của mình để tăng thêm quỹ từ thiện. Yuzu đã làm tất cả những gì có thể trong khả năng để giúp đỡ mọi người, đồng thời không hề bỏ bê sự nghiệp thi đấu của mình.\r\n\r\nVào tháng 4 năm 2012, “Ngọn lửa xanh” được phát hành, tính cách mạnh mẽ quyết liệt cùng với lòng đam mê nhiệt huyết đầy chân thành được truyền tải, đã nhanh chóng trở nên nổi tiếng và chiếm trọn niềm yêu quý mến mộ tại Nhật Bản. Một phần số tiền bản quyền của “Ngọn lửa xanh” được Yuzu quyên góp cho công việc sửa chữa sân băng Sendai quê nhà, nơi đã bị phá hủy bởi trận động đất.\r\n\r\nCuốn tự truyện thứ hai của Yuzuru Hanyu phát hành năm 2016 có tên “Ngọn lửa xanh – Bay cao” viết tiếp câu chuyện tuyệt đẹp về hành trình chinh phục đỉnh cao của “hoàng tử sân băng”.\r\n\r\nCó một sự thật mà Yuzu không nhắc đến trong cuốn tự truyện, là căn bệnh hen suyễn được chẩn đoán vào năm 2 tuổi. Vì hen suyễn nên điểm yếu của Yuzu là sức bền kém, cũng vì thế mà dễ bị chấn thương. Nhưng Yuzu chưa từng lấy bệnh hen ra làm lí do biện minh cho bản thân.\r\n\r\nĐam mê, tự tin, khiêm tốn, kỹ tính, kiên định, lòng hiếu thắng có một không hai… là những tính từ nổi trội khi nói về Yuzu. Đó là một vận động viên không những muốn thi đấu tốt mà còn luôn tìm kiếm bản sắc của riêng mình – bản sắc Yuzuru Hanyu. Có lẽ tất thảy những điều ấy đã tạo nên thành công đáng kinh ngạc trong tương lai của Yuzu mà cả thế giới đã được chứng kiến.\r\n",
                    Meta = "Ngọn lửa xanh – Tự truyện đầu tiên Yuzuru Hanyu",
                    UrlSlug = "ngon-lua-xanh–tu-truyen-dau-tien-yuzuru-hanyu",
                    ImageUrl = "https://reviewsach.net/wp-content/uploads/2022/09/Ngon-lua-xanh-reviewsachnet-1068x801.jpeg",
                    Published = true,
                    PostedDate = new DateTime(2020, 5, 3, 19, 5, 0),
                    ModifiedDate = null,
                    ViewCount = 100,
                    Author = authors[16],
                    Category = categories[7],
                    Tags = new List<Tag>()
                    {
                        tags[0],
                        tags[3],
                        tags[8],
                        tags[17]
                    }
                },

                //================================================15

                new()
                {
                    Title = "Nguồn cội – Tiếng nói của một bản dạng văn hóa linh hoạt",
                    ShortDescription = "Cũng là “Nguồn cội”, nhưng là “Nguồn cội” của Đan Thy chứ không phải của Dan Brown, và hẳn nhiên, đây không phải là một cuốn tiểu thuyết kinh dị bí ẩn. “Nguồn cội” của Nguyễn Đan Thy (Thy Nguyen) là một tuyển tập những truyện ngắn và thơ, viết về văn hóa và bản sắc cá nhân, về bản dạng văn hóa phức tạp đã từng chênh vênh nhưng linh hoạt tìm cách thoát khỏi vùng u minh, để tự tin hòa nhập.",
                    Description = "Nguyễn Đan Thy sinh ra và lớn lên tại Sài Gòn, năm 12 tuổi cô rời Việt Nam sang Mỹ định cư, khởi đầu hành trình trưởng thành với nhiều khó khăn khi đứng giữa hai bản sắc văn hoá đầy khác biệt. Những trang viết trong “Nguồn cội” là tiếng nói từ bên trong cộng đồng những người hai quê hương mong muốn được sẻ chia, được lắng nghe, được đồng cảm và được tôn trọng.\r\n\r\n“Nguồn cội” gồm 5 phần lớn, chia ra 14 chương nhỏ chưa kể Lời nói đầu và Lời kết. Bố cục cố gắng phác họa toàn bộ quá trình từ lúc chuẩn bị di dân, bắt đầu định cư, những nỗi sợ, những cảm xúc không yên, tự ti, mất kết nối… đến chấp nhận và hòa nhập. Lần lượt qua từng mẩu chuyện, từng bài thơ, Đan Thy ghi lại trải nghiệm của cá nhân và của những người giống mình.\r\n\r\nHọ phải sống và tập hòa nhập vào môi trường mới khi trong lòng mang nặng phức cảm tự ti, nỗi mặc cảm của kẻ sống bám, của loài ký sinh, vì sự khác biệt từ làn da mái tóc đến ngôn ngữ cùng văn hóa, cho tới ngày họ có thể đứng vững trên đôi chân của mình. Ở đất nước văn minh luôn vỗ ngực tự xưng là “Tự do công lý cho tất cả mọi người” đó vẫn tồn tại đầy rẫy người mang định kiến và phân biệt chủng tộc, đỉnh điểm bài ngoại là khi xuất hiện “loài virus châu Á”. Đối với người bản xứ là một trò đùa, một hành động nhất thời, nhưng đối với những người trong cuộc là từng bước bị đọa đày trong luyện ngục văn hóa.\r\n\r\nNhững nan đề đầy khắc khoải về bản sắc và nhân dạng của người tha hương từng được Giáo sư Viet Thanh Nguyen – nhà văn gốc Việt đầu tiên đoạt giải Pulitzer văn học – khai thác trong tác phẩm “Người tị nạn”. Sẽ rất khập khiễng nếu đặt “Nguồn cội” và “Người tị nạn” lên hai đầu cán cân với mục đích so sánh, nhưng dễ dàng khi xếp chúng vào cùng một đề tài văn chương – viết về nhóm người mang trong mình đa dạng căn tính – sẽ thấy mảnh đất này còn sơ khai và cần nhiều hơn những tiếng nói từ bên trong cộng đồng ấy, như Viet Thanh Nguyen, như Thy Nguyen.\r\n\r\nToàn cầu hóa xoá mờ ranh giới giữa các quốc gia, làm co hẹp khoảng cách địa lý, đẩy nhanh tốc độ biến đổi về cấu trúc kinh tế – chính trị trong quan hệ liên quốc gia, đa quốc gia, kéo theo những chuyển đổi mạnh mẽ về đời sống văn hoá – xã hội của nhân dân khắp thế giới.\r\n\r\nTrong thế giới toàn cầu hóa, số lượng công dân toàn cầu – những người sống và làm việc ở nhiều quốc gia khác nhau, có thể có một hoặc nhiều quốc tịch – tăng lên nhanh chóng. Theo Báo cáo Di dân Thế giới năm 2020 từ Tổ chức Di dân Quốc tế của Liên Hợp Quốc (IOM), tỉ lệ di dân quốc tế liên tục tăng trong những năm gần đây, ước đoán con số di dân toàn cầu lên đến 272 triệu. Bản dạng hay bản sắc văn hóa bởi vậy mà ít cứng nhắc đi, dần trở nên linh hoạt hơn.\r\n\r\n“Khi người ta hỏi tôi từ đâu đến, tôi nói sự thật, “Tôi sinh ở Việt Nam rồi chuyển đến đây lúc đang học cấp hai. Vậy nên tôi đến từ cả hai nơi – Sài Gòn và Houston.” Tôi tự hào vì mình có hai căn tính. Tôi trân trọng sự khác biệt và đa dạng trong mình. Tôi thấy chỉ nhận mình là người Việt hoặc người Mỹ là không đúng. Tôi chẳng là gì cả, đồng thời tôi lại là cả hai. Tôi là sự pha trộn của những mảnh ghép, tôi là tôi.\r\n\r\nTôi là Nguyễn Đan Thy và tôi cũng là Tee Win, một chút Việt, một chút Mỹ, thoải mái mở bất cứ cánh cửa nào. ”Xét một cách khách quan, từ nội dung đến ngôn từ, “Nguồn cội” của Nguyễn Đan Thy không quá xuất sắc, cũng không thực sự cuốn hút. Nhưng tác phẩm là tiếng nói thiết tha khơi gợi ý thức về sự giao thoa văn hóa, đồng thời khích lệ mọi người trân trọng và ca tụng sự khác biệt, để mỗi người cảm thấy tự hào về chính màu da của mình. Vì vậy, “Nguồn cội” có lẽ đã hoàn thành sứ mệnh.\r\n",
                    Meta = "Nguồn cội – Tiếng nói của một bản dạng văn hóa linh hoạt",
                    UrlSlug = "nguon-coi-tieng-noi-cua-mot-ban-dang-van-hoa-linh-hoat",
                    ImageUrl = "https://reviewsach.net/wp-content/uploads/2022/03/Anh-thekibrary_-Nguon-coi-reviewsachonly-840x840.jpg",
                    Published = true,
                    PostedDate = new DateTime(2023, 3, 3, 8, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 308,
                    Author = authors[17],
                    Category = categories[2],
                    Tags = new List<Tag>()
                    {
                        tags[1],
                        tags[4],
                        tags[3],
                        tags[6],
                        tags[10]
                    }
                },

                new()
                {
                    Title = "Hồn Trương Ba da hàng thịt – Chuyện cũ viết theo lối mới",
                    ShortDescription = "Hồn Trương Ba da hàng thịt của Lưu Quang Vũ là một trong những kịch phẩm thành công và tiêu biểu nhất cho tài năng, phong cách của ông. Với vở kịch này, Lưu Quang Vũ đã khai thác và làm mới truyện cổ tích cùng tên với những xử lý thông minh, tài tình theo hướng lạ hóa để tái sinh truyện gốc trong một loại hình mới, một thể loại mới với những nhân vật mới, cốt truyện mới, xung đột mới,… phù hợp với thời đại, tư tưởng cũng như quan niệm, mục đích văn chương của tác giả. ",
                    Description = "Hồn Trương Ba da hàng thịt có nguồn gốc trực tiếp và rõ ràng từ truyện cổ tích cùng tên của văn học dân gian Việt Nam. Kịch của Lưu Quang Vũ đã giữ lại cơ bản hạt nhân cốt truyện dân gian: cái chết đột ngột và sự tái sinh trong thể xác anh hàng thịt của Trương Ba, gây nên sự tranh giành người chồng giữa hai người vợ của Trương Ba và anh hàng thịt. Truyện cổ đã giải quyết xong xuôi số phận của “hồn Trương Ba da hàng thịt” dựa vào sự thắng thế của linh hồn đối với thể xác trong việc định vị con người, nhưng kịch của Lưu Quang Vũ lại tiếp nối câu chuyện bằng việc đặt ra và trả lời câu hỏi: “hồn Trương Ba da hàng thịt” đã sống như thế nào từ sau phán quyết thoạt nghe rất có lý đó – và đây lại chính là phần cốt lõi, trọng tâm nhất trong vở kịch của Lưu Quang Vũ.\r\n\r\nTừ truyện cổ sang vở kịch hiện đại, Hồn Trương Ba da hàng thịt đã có những biến đổi đáng kể. Đó không chỉ là sự thay đổi hình thức bên ngoài mà là sự thay đổi sâu xa bên trong nội dung, chủ đề tư tưởng của tác phẩm thông qua việc lưu giữ và sáng tạo những yếu tố thuộc thành phần cốt truyện. Những chi tiết cơ bản của truyện cổ được tái sử dụng ở một mức độ đủ để gợi nhắc khán giả về truyện gốc – tức cái đã biết, cái quen thuộc, nằm trong “tầm đón đợi” của người tiếp nhận, có tính chất như phần mào đầu cho một câu chuyện đầy bi kịch sắp mở ra ở phần sau vở kịch. Trong khi đó, những phần sáng tạo chiếm nhiều ưu thế, tạo nên những khác biệt rõ rệt so với truyện gốc. Vì vậy, có thể nói, vở kịch của Lưu Quang Vũ không chỉ cải biên mà còn mở rộng, thay đổi cốt truyện của truyện cổ: khi truyện cổ khép lại, thì vở kịch thật sự của Lưu Quang Vũ chỉ mới bắt đầu. Trong trường hợp này, vở kịch Hồn Trương Ba da hàng thịt không đơn thuần chỉ là sự chuyển thể, là viết lại mà là quá trình sáng tạo thực thụ của chính tác giả.\r\n\r\nSo với truyện gốc, thế giới nhân vật trong hai vở kịch có sự khác biệt rất lớn. Kịch Hồn Trương Ba da hàng thịt có số lượng nhân vật đông đảo hơn hẳn so với truyện cổ khi vở kịch của Lưu Quang Vũ còn có thêm hàng loạt các nhân vật hoàn toàn mới: Nam Tào, Bắc Đẩu, anh con trai của Trương Ba, chị con dâu Trương Ba, cái Gái (cháu nội Trương Ba), cu Tị (bạn cái Gái), lái lợn 1, lái lợn 2, trương tuần. \r\n\r\nSự khác biệt của nhân vật trong kịch Hồn Trương Ba da hàng thịt so với truyện gốc không đơn thuần chỉ là sự gia tăng về số lượng mà còn thể hiện thông qua cách thức xây dựng, khắc họa nhân vật hoàn toàn mới lạ. Các nhân vật trong truyện cổ tích chưa có tính cách, tâm lý rõ rệt. Hành động, ngôn ngữ, suy nghĩ còn đơn giản, một chiều. Trong khi đó, nhân vật trong kịch lại hiện lên sinh động, vẹn toàn như một con người trong đời thực từ nhân vật chính (Trương Ba) cho đến các nhân vật phụ (xuất hiện trực tiếp hay vắng mặt). Trong số các yếu tố nhằm làm “lạ hóa” Trương Ba trong truyện cổ thì việc trình hiện những diễn biến tâm lý của nhân vật này sau khi tái sinh và rơi vào cảnh ngộ oái ăm hồn ta, xác người là then chốt và quan trọng nhất. Chính sự hiện hữu của những dằn vặt, mâu thuẫn đó là cơ sở tạo nên xung đột kịch, thúc đẩy vở kịch đến cao trào trong quá trình hồn vừa thích ứng lại vừa phản kháng lại xác. Nhân vật Trương Ba từ đây thoát khỏi nguyên gốc là nhân vật loại hình, chức năng theo thi pháp của truyện cổ dân gian, trở thành một nhân vật – con người phức tạp của văn học hiện đại. Và hơn hết, yếu tố này cũng góp phần làm thay đổi tư tưởng, triết lý của truyện gốc: từ việc coi trọng, thậm chí tuyệt đối hóa vai trò của linh hồn đối với thể xác đến việc đòi hỏi, yêu cầu phải có sự hòa hợp giữa thể xác và linh hồn để con người được tồn tại trong sự toàn vẹn của chính nó. Bất kì một sự chênh lệch, khập khiễng nào cũng sẽ làm “tha hóa” bản thể, dẫn nguồn đến muôn vàn bi kịch hiện sinh cho con người. \r\n\r\nTrong truyện cổ Hồn Trương Ba da hàng thịt xung đột được hình thành từ mâu thuẫn giữa hai người vợ trong việc tranh giành “hồn Trương Ba da hàng thịt”. Từ xung đột bên ngoài, đơn giản, diễn ra giữa hai đối tượng biệt lập trong truyện cổ, xung đột trong kịch của Lưu Quang Vũ đã chuyển thành xung đột bên trong nhân vật, phức tạp, quyết liệt và căng thẳng. Không thể có sự thỏa hiệp, xung đột này phải được giải quyết dựa trên sự tiêu vong của một trong hai chủ thể tạo nên xung đột: hoặc hồn, hoặc xác. Lựa chọn rời bỏ một thân xác không phải của mình, không thể hòa hợp với phần hồn và chấp nhận chấm dứt sự tồn sinh, hiện hữu của mình của Trương Ba đã giải quyết xung đột kịch. Đó là sự giải thoát cho Trương Ba khỏi sự vay mượn thể xác của người khác, là hành trình quay trở về với chính mình và tái sinh lại hình ảnh một Trương Ba thanh sạch, đôn hậu, hiền từ trong nhận cảm của những người ở lại. Có thể thấy, khi Trương Ba được Đế Thích cho tái sinh trong thân xác anh hàng thịt thì bắt đầu từ đó, Trương Ba lại đối mặt với quá trình đánh mất chính mình. Người thân của Trương Ba chưa kịp vui mừng vì ông ta sống lại đã phải đau buồn vì sự tha hóa của Trương Ba. Đến khi Trương Ba quyết định chết lần nữa (cũng là chết mãi mãi), thì Trương Ba lại như được tái sinh khi tìm thấy chính mình. Vở kịch vì vậy tuy kết thúc bằng sự ra đi của Trương Ba song lại mang màu sắc lạc quan, tích cực. \r\n\r\nKiến tạo một xung đột mới trên cơ sở một cốt truyện cũ với xung đột cũ, Lưu Quang Vũ đã tạo nên sự đối thoại với tư tưởng triết lý và quan niệm nhân sinh trong truyện cổ về mối quan hệ giữa hồn và xác. Ông đã đặt lại vấn đề, phản biện lại với quan niệm xem hồn là phần quan trọng, mang tính quyết định với thể xác và xem nó như là đại diện cho toàn bộ sự tồn tại của mỗi người của truyện gốc. Đồng thời, tác giả cũng lồng ghép vào đó những vấn đề khác của đời sống khi ông chỉ ra thói xảo ngụy của những kẻ lấy sự quan trọng của phần hồn để biện minh cho sự cẩu thả về thể xác, tương tự là những kẻ ngụy biện cho sự tha hóa nhân cách, đạo đức bằng sự thống ngự của những đòi hỏi thể xác. Tính mới mẻ, thời sự, hiện đại trong tác phẩm của Lưu Quang Vũ đã được thiết lập trên nền tảng của một xung đột kịch đầy xa lạ  với truyện gốc, tạo nên những thức nhận bất ngờ, mới lạ trong quá trình tiếp nhận của khán giả.\r\n",
                    Meta = "Hồn Trương Ba da hàng thịt – Chuyện cũ viết theo lối mới",
                    UrlSlug = "hon-truong-ba-da-hang-thit-chuyen-cu-viet-theo-loi-moi",
                    ImageUrl = "https://reviewsach.net/wp-content/uploads/2021/07/reviewsach.net-hon-truong-ba-da-hang-thit.jpeg",
                    Published = true,
                    PostedDate = new DateTime(2018, 8, 3, 17, 45, 0),
                    ModifiedDate = null,
                    ViewCount = 450,
                    Author = authors[16],
                    Category = categories[2],
                    Tags = new List<Tag>()
                    {
                        tags[17],
                        tags[3],
                        tags[10],
                        tags[16]
                    }
                },

                new()
                {
                    Title = "Cát bụi chân ai – Tô Hoài",
                    ShortDescription = "Nguyễn Tuân, Nguyên Hồng, Xuân Diệu, Nguyễn Bính,… biết bao là kì tài văn chương lúc bấy giờ, biết bao là kỉ niệm thuở vàng son vang bóng, biết bao những náo nhiệt, say mê, đau đớn của tuổi trẻ,… Tô Hoài đã gói trọn cả đời mình trong cuốn hồi kí ấy, và cũng gói trọn cả thời đại của mình trong những dòng chữ thấm đượm khao khát mà đớn đau.",
                    Description = "Tô Hoài bắt đầu miêu tả về Nguyễn Tuân một cách đầy dò xét, với những “tư liệu” chủ yếu thông qua vài người bạn hay những lần bắt gặp ít ỏi. Nguyễn Tuân trong tâm trí ông khi ấy là nhà văn chơi chua khác đời: “Khăn lướt vố, áo gấm trần, tay chống dọc chiếc quạt thước thay ba toong, chân bút tất dận giày mõm nhái Gia Định”. Chẳng những cái kiểu ăn mặc thật khác thường mà cả tính tình lẫn văn chương Nguyễn Tuân cũng khiến nhiều người khi đó phải lôi ra bàn qua bàn lại, có người say như điếu đổ, có người lại không chịu được cái giọng khụng khiệng, khệnh khạng ấy. Thế nhưng chẳng biết từ bao giờ, Tô Hoài lại dần bị cuốn vào cái tư chất lạ lẫm ấy của Nguyễn Tuân, lặng lẽ qua sát người đồng nghiệp hơn mình mười tuổi qua những tác phẩm in trên tuần báo, qua vai diễn người đi săn ở kịch Ngã ba, qua lần bắt gặp ở nhà hàng Hoàng Gia, qua những báo cáo của Như Phong ở buổi họp bí mật của hội Văn hóa Cứu quốc,… Hai con người ấy chẳng từng quen biết, không chút thân thuộc, chỉ “nhẹ vương” vào đời nhau bằng những lời đồn thổi xa gần hay những lần vô tình bắt gặp giữa Hà Nội náo nhiệt, rộng lớn. \r\n\r\nDòng kí ức cứ lần lướt, hết kể về mấy cái thói quen ăn uống, quán xá của Nguyễn Tuân, lại khẽ nhắc mấy dòng về cái thập niên hồi tác giả còn đương bôn ba khắp chốn. Những mẩu chuyện của hai cá nhân tách biệt lại đan xen cùng những kỉ niệm trên chặng đường chung, luân phiên nhau choán lấy tâm trí người đọc. Đó là một bức tranh bình thản, nhẹ nhàng nhưng cực kì chi tiết, vô cùng tỉ mỉ. Tựa như không thiếu mất bất kì cái bộ dáng nhỏ nhặt nào của Nguyễn Tuân: từ lúc ngồi lặng lẽ bên cốc cà phê nguội ngắt trên đường Hà Nội, đến lúc ăn phở tinh tế mà cũng kén chọn đủ đường, và cả khi mạnh mẽ trèo đèo lội suối với tinh thần người chiến sĩ,… Những ghi chép lặng lẽ ấy đủ để cho ta thấy niềm trân trọng cháy bỏng trong trái tim Tô Hoài đã trói chặt kí ức ấy thế nào.\r\n\r\nNếu nói chương 1 là thế giới kỉ niệm của Tô Hoài với khách mời là Nguyễn Tuân – chậm rãi và tuần tự, thì chương 2 lại là một bức tranh hồi ức đông vui, sống động đến náo nhiệt hơn hẳn. Đâu là Nguyên Hồng, Kim Lân, Ngô Tất Tố, đâu cả Nguyễn Bính, Văn Cao,… mỗi người một nết, một vẻ, quyện thành sắc mài, phong phú và rạo rực đấy, mà cũng dở khóc dở cười.\r\n\r\nLúc bấy giờ, tất thảy bọn họ đều đang đương đầu một cách đầy bỡ ngỡ với biết bao thứ mới mẻ của một cuộc chuyển vần thế kỉ, của một thời đại mới. Mà khi ấy, Tô Hoài cũng vừa được giao đảm nhận công việc ở các nhà xuất bản, bắt đầu bận rộn bên những công tác văn chương, báo chí cùng anh em đồng nghiệp. Thế là lại có hẳn một thiên truyện vui buồn lẫn lộn, về cái tháng năm đầy sôi nổi mà cũng thật lắm điều ồn ào xoay vần làm người ta chếnh choáng.\r\n\r\nTô Hoài đã cho ta thấy một góc khác của Nguyễn Bính, bằng một cái nhìn trực diện với điểm nhìn gần nhất. Ông không ngại kể thẳng thừng mấy tật xấu của Nguyễn Bính, viết lên giấy một con người không còn đậm chất thơ, không được tinh tế mê đắm như chính cái vần thơ của người thi sĩ ấy. Tô Hoài viết về ông với một hình ảnh thường xuyên say xỉn, với những cùng quẫn tự chuốc, những đau thương vơ vào, mình lại đày ải mình, thân làm tội đời, cứ thế miên man và xuyên suốt cho tới tận những ngày sau mà mãi vẫn không nguôi.\r\n\r\nNguyên Hồng thì hay khóc, ngắn gọn có thể nói là vậy. Kể như chỉ tới ăn một bữa bánh tráng của bà Lâm mà “hàng nước mắt đã chan chứa hai gò má, rồi lại ngồi xuống nhồm nhoàm ăn, nước mắt vẫn lã chã.”. Cái cảm xúc luôn dâng trào không màng lúc nào hay chỗ đâu ấy, được Tô Hoài đỡ vui gọi là “những cảm hứng giữa đường giữa chợ” đã như một thói quen với tất cả anh em, bạn bè xung quanh. Hay rõ ràng nhất phải kể đến câu chuyện phê bình của các nhà văn. Riêng mình Nguyên Hồng mà kiểm điểm một buổi vẫn chưa xong. Người ta sợ đụng đến, lại phân tích, lại bổ sung, lại tôi xin góp ý với đồng chí thì chắc chắn lại như hôm qua, rồi hôm kia, Nguyên Hồng xòe bàn tay lên chồng báo, vuốt vuốt, mếu máo nói, nước mắt như trút… Thế là không ai nói chen vào được nữa. Và hẳn là không ai giám hỏi thêm câu gì. Nguyên Hồng hiện lên như một nét chấm vui lạ thường, buồn khó hiểu, hơn thế cũng thật cả tin và hồn nhiên tới lạ. Có chăng vì thế mà làm điểm lên giữa những trang văn chất chứa đầy phức tạp, đan xen của cơ quan, của thời đại, một tiếng cười nhẹ trong sáng, một chút vui tươi, hài hước bật ra khỏi bức bối, đè nén buổi đương thời.\r\n\r\nTập kí mở đầu càng bình thản bao nhiêu thì những chương khép lại càng giông tố, đau thương bấy nhiêu. Bọc quanh con chữ sao toàn những bom đạn giằng xé, tiếng còi báo động siết lấy những bàn phở gà che mái lá. Một Hà Nội sống động và náo nhiệt, ngày đêm đón những đợt máy bay lượn trên đầu, oằn mình giữa đợt bom xối xả. Thế nhưng giọng văn vẫn nghe như bình thản. Không than phiền hay đau đớn, cứ điềm tĩnh khắc lên từng hồi ức, hệt như sự vững chãi của sự sống nơi đây – liên tục sinh sôi, chuyển động bất chấp mỗi lần đổ sập, mất mát. \r\n\r\nVậy mà ở trang cuối cùng, người ta thấy những dòng cảm thán hiếm hoi, hoặc có lẽ là duy nhất. Những cảm xúc lẫn lộn chưa kịp thành hình, in trong trái tim Tô Hoài rồi cả lên trang văn tập kí, sau cái chết đột ngột của Nguyễn Tuân. Cái chết ấy chấm dứt quyển bút kí của Tô Hoài, và đâu đó có chăng, tựa như dấu chấm lửng của một thời đại vàng son vang bóng.\r\n\r\nĐọc hồi kí, người ta chê Tô Hoài sao mà vô tình, sao mà tàn nhẫn thế! Hết vạch trần mọi tật xấu, mọi gàn dở của bạn đồng môn lại kể chuyện với những con chữ ít tình, nhiều thực họa. Ai biết chăng, cái tình ấy đã pha vào biết bao hỗn loạn của thời đại, đã chìm trong bao xót xa âm ỉ của một thời tuổi trẻ. Tô Hoài phải yêu, phải giữ trong tâm sâu sắc đến mức nào, mới có thể đem tất thảy mọi chuyện: ăn uống, công tác,… viết ra rành mạch, sống động đến thế. Những con người tài hoa ấy đã bỏ qua mọi gàn dở, ngang ngược của nhau để làm bạn, để sống và đối đãi với nhau một cách chân thật nhất, trọn một kiếp người.\r\n\r\nĐọc một lần thì thấy Tô Hoài như đang “vạch áo cho người xem lưng” hết cả giới văn chương bấy giờ. Nhưng càng ngẫm, ta lại càng ngậm ngùi cho những kiếp đời, kiếp tình ấy. Ông không nói thương, nói buồn, chẳng bảo vui hay ghét, giọng nói văng vẳng suốt cả áng văn cứ như điềm nhiên, phẳng lặng, không thấy đâu những gợn của sóng tình. Niềm thương của Tô Hoài được gửi ở chính những cái xấu, cái dở của bạn bè mà ông chọn viết. Đó là những thứ khiến các bậc thi nhân “ôm trọn khối đời” mà ta vẫn tưởng, trở nên “người thường” hơn bất kì người thường nào khác. Tình yêu của nhà văn đối với mỗi ai trong số họ đều xuất phát từ chính con người đầy khiếm khuyết dở người ấy, chứ không phải một Nguyễn Tuân, Nguyên Hồng, Nguyễn Bính,… lẩn khuất sau những trang văn. Người này tính này, người nọ tật kia, chả ai giống ai, nhưng điểm chung của họ là đã sống trọn đời mình cho văn chương, cho khao khát say tình đắm mộng, cho hoài bão thay đổi thời đại. Mà những mãnh liệt, cuồng nhiệt ấy, đã bị năm tháng mài mòn, rút cạn, cuối cùng kẻ đi người ở, chấm hết một kiếp duyên nhân sinh đầy xáo động.\r\n",
                    Meta = "Cát bụi chân ai – Tô Hoài",
                    UrlSlug = "cat-bui-chan-ai-to-hoai",
                    ImageUrl = "https://reviewsach.net/wp-content/uploads/2021/05/reviewsach.net_.-cat-bui-chan-ai--1068x815.jpeg",
                    Published = true,
                    PostedDate = new DateTime(2018, 3, 3, 17, 45, 0),
                    ModifiedDate = null,
                    ViewCount = 877,
                    Author = authors[10],
                    Category = categories[2],
                    Tags = new List<Tag>()
                    {
                        tags[0],
                        tags[4],
                        tags[11],
                        tags[16]
                    }
                },

                new()
                {
                    Title = "Những đứa trẻ đuổi theo tinh tú hay câu chuyện về những con người tìm về một giấc mơ",
                    ShortDescription = "Trong quá khứ, đã từng có một Shinkai Makoto dịu dàng, dung dị và tối giản vô cùng vô tận ở những bộ phim, câu chuyện ngắn như Kanojo to kanojo no neko – Nàng và con mèo của nàng. Nhưng hiện tại, lại có một Shinkai Makoto khiến người ta đắm say với các thước phim tráng lệ như một bữa tiệc của tình tiết hòa quyện với đồ họa, âm thanh.",
                    Description = "Những đứa trẻ đuổi theo tinh tú, bộ phim được công chiếu vào năm 2011, một trong các tác phẩm có thời lượng dài nhất của Shinkai cho tới hiện tại, cũng không nằm ngoài tư duy nghệ thuật ấy. Để từ đó, tiểu thuyết cùng tên được Akisaka Asahi chắp bút chuyển thể từ ngôn ngữ điện ảnh sang ngôn ngữ văn chương đã phần nào lưu giữ, tái hiện được trọn vẹn “chất Shinkai Makoto”.\r\n\r\nNhững đứa trẻ đuổi theo tinh tú, cuốn sách nhỏ chưa đầy 200 trang có một tựa đề đầy thơ mộng, rất gợi, rất thơ, đủ mang tới cho độc giả nhiều suy tư cùng liên tưởng. Tại sao lại là “những đứa trẻ”? “Những đứa trẻ” ở đây là chỉ những đối tượng nào? “Tinh tú” là gì? Là một ngôi sao cụ thể hay là hình ảnh mang ý nghĩa biể tượng nào đó. Và những đứa trẻ kia, vì lý do gì lại phải đuổi theo tinh tú, hành trình ấy sẽ diễn ra như thế nào, có thật thuận lợi, kết quả chúng có thể hoàn thành được tâm nguyện của mình?\r\n\r\nQuả thực, từ một tiêu đề đầy tính gợi hình, gợi tả, Shinkai Makoto đã mở ra cả một không gian truyện tựa như cổ tích. Ngay chính trong lòng đất nước Nhật Bản thời hiện đại, có một mảnh đất tựa rêu phong phủ kín: Mizonofuchi. Mảnh đất ấy, lại ở ngay phía trên một thế giới dưới lòng đất đang mỗi lúc một suy tàn: Agartha. Cho nên, Những đứa trẻ đuổi theo tinh tú, câu chuyện đấy cứ bảng lảng như thực như hư trong những lời kể, trong những dòng không gian xáo trộn, trong những dòng tâm trạng hay những kí ức, suy tưởng vụn vỡ của con người.\r\n\r\nKhông gian sáng tác tựa như cổ tích, dòng thời gian chảy trôi của các tình tiết cũng như một câu chuyện huyền thoại được viết bằng bút pháp hiện đại. Bởi thời gian ở Những đứa trẻ đuổi theo tinh tú là một dòng thời lưu có nhiều xáo trộn, đan xen giữa hiện thực – quá khứ; vừa là sự tỉnh lược trong những lời trần thuật, vừa là sự kéo dài mỗi khoảnh khắc, mỗi đêm khó khăn, vất vả của cuộc trình giữa hai thầy trò Asuna – Morisaki. Từ đó, mà cốt truyện dần thành hình và độc giả, không chỉ hiểu về nội dung mà còn hiểu sâu về tư tưởng, tình cảm người viết gửi gắm vào tác phẩm, ngay từ các con chữ đầu tiên, xuất hiện trên tựa đề.\r\n\r\nVà trong buổi học sau đó, Asuna lại được nghe thầy giáo Morisaki nhắc tới mảnh đất Agartha, nơi có thể hồi sinh được người chết. Rồi như định mệnh, Asuna gặp gỡ em trai Shun – Shin, người đến mặt đất lấy lại viên tinh thể Shun để lại. Cô bé, vì quá đỗi kinh ngạc trước sự giống nhau giữa Shin – Shun và nhất là với khao khát cứu sống lại người bạn quá cố, đã cố gắng theo chân cậu bé tới mảnh đất xa lạ kia. Giữa đường, họ gặp cuộc tập kích của những kẻ cũng ôm ấp mưu đồ tới Agartha, trong đó có thầy Morisaki, người đang mang tâm nguyện hồi sinh vợ.\r\n\r\nBa con người, mang ba nỗi niềm, tiến đến Agartha, miền đất trong truyền thuyết, nơi lưu dấu những tri thức cổ xưa, nơi cất giữ những bí ẩn cổ đại nhất của nhân loại, nơi ẩn chứa những sức mạnh nằm ngoài tầm với, sự hiểu biết của con người. Và cũng như rất nhiều câu chuyện cổ tích khác, Những đứa trẻ đuổi theo tinh tú, từ mảnh đất của truyền thuyết, với những huyền thoại được thêu dệt, mà con người gửi gắm vào đấy ước mơ, hi vọng. Ước mơ hồi sinh người đã mất, ước mơ được gặp người quá cố, ước mơ tìm về một phần ký ức đã xa, ước mơ được sống những giây phút chẳng còn cô đơn, phiền muộn. “Tinh tú”, vì thế, đâu chỉ tượng trưng cho bầu trời đêm lấp lánh ánh sao trong lần đầu Asuna và Shun gặp gỡ. Đó còn là biểu tượng cho những giấc mơ đẹp, có phần xa xôi nhưng người ta vẫn mãi kiếm tìm, mãi đuổi theo, mãi vươn đến. Bởi, còn đuổi theo tinh tú, con người còn mục đích để tiếp tục sống, tiếp tục hướng đến ngày mai.\r\n\r\nNhư đã nói, những tác phẩm của Shinkai Makoto, dù trước kia hay bây giờ, dù hiện thực hay hư ảo, đều chuyên chở ở đó những tầm sâu văn hóa và tâm thức rất riêng của con người Nhật Bản thời hiện đại. Và Những đứa trẻ đuổi theo tinh tú cũng không nằm ngoài tư duy nghệ thuật ấy Shinkai.\r\n\r\nDẫu rằng phần lớn dung lượng cuốn sách nhắc đến Agartha, một địa danh không có thực; nhưng không vì thế mà bóng hình Nhật Bản với vẻ đẹp cổ kính, trang nghiêm trong cảnh sắc thiên nhiên, trong những dấu tích văn hóa, sinh hoạt đời thường của con người trở nên phai nhạt.\r\n\r\nQuê hương cô bé Asuna sinh sống, thị trấn Mizonofuchi, nơi có trường tiểu học Mizonofuchi như ngưng đọng lại những trầm tích thời gian, lịch sử của một nước Nhật giàu truyền thống. “Ngôi trường bằng gỗ được dựng từ đầu thời Chiêu Hòa, cổ kính, đượm màu thời gian”. Và chính cái tên Mizonofuchi – nghĩa đen tức đáy sâu cũng như gói ở đó bao lắng đọng của cả vật chất lẫn tinh thần của mỗi bước chuyển thời gian ở xứ sở này.\r\n\r\nNgọn núi ở Obuchi, mũi đất cô bé Asuna vẫn thường đến để thu bắt tín hiệu cho chiếc radio tinh thể có ý nghĩa biểu tượng như chiếc cổng Tori trong văn hóa Nhật Bản: nối liền hai không gian, gắn kết những chiều thời gian để mở ra hai thế giới vẫn luôn song song tồn tại.\r\n\r\nVà ngay chính vùng đất truyền thuyết Agartha, cũng mang dáng dấp một Nhật Bản cổ xưa, với những nét đẹp truyền thống, những tri thức cổ đang dần đến bờ vực mai một, thất truyền giữa dòng xoáy của thời gian, của lòng người.\r\n",
                    Meta = "Những đứa trẻ đuổi theo tinh tú hay câu chuyện về những con người tìm về một giấc mơ",
                    UrlSlug = "nhung-dua-tre-duoi-theo-tinh-tu-hay-cau-chuyen-ve-nhung-con-nguoi-tim-ve-mot-giac-mo",
                    ImageUrl = "https://reviewsach.net/wp-content/uploads/2020/02/Nhu%CC%9B%CC%83ng-%C4%91u%CC%9B%CC%81a-tre%CC%89-%C4%91uo%CC%82%CC%89i-theo-tinh-tu%CC%81-review-sa%CC%81ch.jpg",
                    Published = true,
                    PostedDate = new DateTime(2020, 8, 19, 20, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 1023,
                    Author = authors[5],
                    Category = categories[7],
                    Tags = new List<Tag>()
                    {
                        tags[3],
                        tags[2],
                        tags[7],
                        tags[6]
                    }
                },

                new()
                {
                    Title = "Nếu biết trăm năm là hữu hạn – Ta sẽ làm chi đời ta?",
                    ShortDescription = "Không đao to búa lớn, không khó hiểu, không giáo điều, “Nếu biết trăm năm hữu hạn” là những bài cảm thức giản dị và chân thành của Phạm Lữ Ân, độc giả có cơ hội được thể nghiệm thế giới quan của tác giả, để nhìn và để nghĩ suy, có thể đồng cảm và cũng có thể không tán thành… về những vấn đề nhỏ bé nhưng không tầm thường.",
                    Description = "“Nếu biết trăm năm là hữu hạn” vốn là tuyển tập hơn 40 bài viết trên chuyên mục Cảm thức của Bán nguyệt san 2! – số Chuyên đề của báo Sinh Viên Việt Nam, nhưng lại chạm được tới nỗi lòng không chỉ riêng các bạn trẻ.\r\n\r\nPhạm Lữ Ân viết về mọi thứ xung quanh cuộc sống con người, không giản đơn, không phức tạp, nhưng đều có chiều sâu nếu nguyện ý khám phá. \r\n\r\nNhư là “nhà” và “bình yên” chẳng hạn, phải chăng “nhà” luôn gắn liền với hai chữ “bình yên”? Hay nơi nào, người nào đem lại cho ta cảm giác thực sự “bình yên” thì nơi đó mới là nhà? Thử đặt câu hỏi và tìm câu trả lời.\r\n\r\nNhư là những lỡ lầm của tuổi trẻ sau khi tìm được cách giải quyết, nhưng vết thương lòng thì còn mãi, và lúc trái gió trở trời nó sẽ sưng tấy lên trong tâm trí họ, ngăn trở họ cảm nhận niềm hạnh phúc.\r\n\r\nNhư là tại sao lại là ‘Độc lập – Tự do – Hạnh phúc’? Tại sao là ‘Hạnh phúc’ chứ không phải là ‘Thịnh vượng’ hay ‘Văn minh’?\r\n\r\nNhư là giá trị riêng biệt của mỗi con người – không phải hơn hay kém, không phải là vịt hay thiên nga – mà là độc nhất, và làm thế nào để biết mình, biết giá trị của mình, tôn trọng, yêu thương và phát huy bản thân trở thành một “mình” tốt nhất.\r\n\r\nNhư là sự may mắn, sự cô độc, sự trống rỗng, sự chờ đợi, quá khứ và tuổi thơ, mối quan hệ với bố mẹ và ông bà, bảo vệ Trái Đất, công việc, ước mơ, tình yêu, tâm hồn, bản ngã… Những gì mà Phạm Lữ Ân viết hoàn toàn không xa lạ, cuộc đời của bất kỳ ai cũng tồn tại các vấn đề ấy, khác chăng là ở suy nghĩ của mỗi người.\r\n\r\nTản văn là một loại hình văn học ngang với thơ, kịch, tiểu thuyết. Tản văn là loại văn xuôi ngắn gọn, hàm súc, có thể trữ tình, tự sự, nghị luận, miêu tả phong cảnh, khắc họa nhân vật.\r\n\r\nTheo bách khoa toàn thư, tản văn có nội hàm rộng hơn khái niệm kí, vì nội dung chứa cả những truyện ngụ ngôn hư cấu lẫn các thể văn xuôi khác như thư, tựa, bạt, du kí,… Lối thể hiện đời sống của tản văn mang tính chất chấm phá, không nhất thiết đòi hỏi có cốt truyện phức tạp, nhân vật hoàn chỉnh nhưng có cấu tứ độc đáo, có giọng điệu, cốt cách cá nhân. Điều cốt yếu là tản văn tái hiện được nét chính của các hiện tượng giàu ý nghĩa xã hội, bộc lộ trực tiếp tình cảm, ý nghĩa mang đậm bản sắc cá tính của tác giả.\r\n\r\nKhách quan mà nói thì tản văn là thể loại văn học có nhiều thú vị vì nó cho phép độc giả nhìn trực diện vào thế giới quan của tác giả.\r\n\r\nThế giới quan của Phạm Lữ Ân tập trung vào các giá trị con người, giá trị gia đình, thái độ lạc quan và cố gắng bao dung với thế giới. Có lẽ thế giới quan của tác giả sẽ trùng với nhiều người trong xã hội này ở thiên hướng tư tưởng thiện lương và chính trực, nỗ lực trở thành một bản thân tốt nhất.\r\n\r\nPhạm Lữ Ân nghĩ về mối quan hệ giữa con người với nhau trong cuộc đời như mạng tinh thể kim cương, đó là một liên tưởng cực kỳ thú vị.\r\n\r\nMỗi con người là một nguyên tử cacbon trong cấu trúc kim cương, có vai trò như nhau và ảnh hưởng lẫn nhau trong một mối liên kết chặt chẽ. Một nguyên tử bị tổn thương sẽ ảnh hưởng đến bốn nguyên tử khác, và cứ thế mà nhân rộng ra. Con người cũng có thể vô tình tác động đến cuộc đời một người hoàn toàn xa lạ theo kiểu như vậy. Thế thì có phải chăng mỗi người sống hạnh phúc chính là đóng góp cho xã hội một cách căn cơ nhất? Sự phát triển và bền vững của một quốc gia phải được xây dựng từ mỗi cuộc đời riêng lẻ của từng người dân?\r\n\r\nQuan điểm trên của Phạm Lữ Ân làm cho người gõ những dòng này chợt nhớ tới “Vẻ đẹp của người chạy marathon về chót” mà Tiến sĩ Đặng Hoàng Giang có nhắc đến trong tác phẩm chính luận “Bức xúc không làm ta vô can”.\r\n\r\nCon người có xu hướng bị thu hút bởi những người xuất chúng và nổi tiếng, rồi rơi vào tâm lý chờ đợi, phó thác, họ không nhận ra giá trị riêng biệt của mình. Nếu bản thân mỗi người tự nhận thức, tự lựa chọn và cố gắng vì lựa chọn đó, như những người lê lết cuối đoàn marathon, thì kết quả được tạo ra từ chính nỗ lực của bản thân chứ không phải chờ đợi, nhòm ngó người khác nữa. Những kẻ dù không chiến thắng nhưng vẫn cố gắng hoàn thành hết đường đua của mình, đó là những người đã chiến thắng chính cuộc chơi của bản thân – Và, họ hạnh phúc với những gì họ đã nỗ lực.\r\n\r\nĐây có lẽ là giá trị cốt lõi mà mỗi một con người nên hướng tới, là nhân tố cốt yếu tạo nên sự thay đổi dần dần tốt đẹp của xã hội, tưởng như giản đơn nhưng giữa những mông lung cuộc đời nhiều người đã không nhận ra.\r\n\r\n\r\n\r\n",
                    Meta = "Nếu biết trăm năm là hữu hạn – Ta sẽ làm chi đời ta?",
                    UrlSlug = "neu-biet-tram-nam-la-huu-han–ta-se-lam-chi-doi-ta",
                    ImageUrl = "https://reviewsach.net/wp-content/uploads/2020/12/Anh-vinhvoxuan-Neu-biet-tram-nam-la-huu-han-reviewsachonly-1068x1068.jpg",
                    Published = true,
                    PostedDate = new DateTime(2020, 12, 30, 16, 45, 0),
                    ModifiedDate = null,
                    ViewCount = 878,
                    Author = authors[15],
                    Category = categories[7],
                    Tags = new List<Tag>()
                    {
                        tags[3],
                        tags[8],
                        tags[11],
                        tags[6]
                    }
                },

                //================================================20





            };

            _dbContext.Posts.AddRange(posts);
            _dbContext.SaveChanges();

            return posts;
        }

        private IList<Book> AddBooks(
           IList<Author> authors,
           IList<Category> categories
           )
        {
            var books = new List<Book>()
            {
                new()
                {
                    Title = "Alice In Borderland - Tập 6 - Tặng Kèm Card Giấy",
                    ShortDescription = "Arisu Ryohei tự nhận mình là một thành phần “ăn hại xã hội”, học hành lẹt đẹt nên đang cực kỳ chán đời.",
                    Description = "Arisu Ryohei tự nhận mình là một thành phần “ăn hại xã hội”, học hành lẹt đẹt nên đang cực kỳ chán đời. Trong một lần tụ tập than vãn cùng hai thằng bạn thân Karube và Chota, cả ba bất chợt nhìn thấy pháo hoa, và sau đó là một vụ nổ long trời lở đất.",
                    Meta = "Alice In Borderland Tap 6",
                    UrlSlug = "alice-in-borderland-tap-6",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/8/9/8934974185628.png",
                    Supplier = "NXB Trẻ",
                    PublishCompany = "Trẻ",
                    CoverForm = "Bìa mềm",
                    StarNumber = 4,
                    ReviewNumber = 100,
                    Price = 120000,
                    ReleasedDate = new DateTime(2020, 4, 21),
                    Author = authors[7],
                    Category = categories[8],
                },
                new()
                {
                    Title = "Hạnh Phúc Cầm Tay (Tái Bản 2021)",
                    ShortDescription = "Cuộc sống quanh ta đầy màu nhiệm, chánh niệm là trái tim của thiền tập, là nguồn năng lượng xuyên suốt không thể thay đổi. Một người sống trong chánh niệm, tâm an, sẽ khiến những người xung quanh vui vẻ, an nhiên và thậm chí thay đổi cả xã hội.",
                    Description = "Bước đi một cách thoải mái, an lạc, đi như không đi sẽ không thấy mệt mỏi. Sự cố gượng là không cần thiết nếu ta hiểu được rằng mỗi bước đi là mỗi bước được tiếp xúc với cuộc đời và sự màu nhiệm vô tận. Chạm vào đất Mẹ là nguồn căn của “Sám Pháp địa xúc”, người thường cũng có thể thực hành khi bế tắc, lo sợ, Người nhẫn nại bảo hộ, che chở và cho ta lối thoát, mọi thứ tự khắc trở nên nhẹ nhàng.\r\n\r\nCuốn sách tiếp tục với Năm uẩn trong một con người: sắc, thọ, tưởng, hành, thức, đều cần ta trị vì, cai quản. Có chánh niệm sẽ nhận diện được tập khí khi chúng đang phát khởi và ngăn ngừa nó hoành hành ta, quấy nhiễu giấc ngủ ta mỗi đêm. Cả những tri giác sai lầm vây bám lấy tâm trí ta, cũng sẽ được loại bỏ.",
                    Meta = "Hạnh Phúc Cầm Tay (Tái Bản 2021)",
                    UrlSlug = "hanh-phuc-cam-tay-tai-ban-2021",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/i/m/image_234141.jpg",
                    Supplier = "Thái Hà",
                    PublishCompany = "NXB Lao Động",
                    CoverForm = "Bìa mềm",
                    StarNumber = 4,
                    ReviewNumber = 120,
                    Price = 75000,
                    ReleasedDate = new DateTime(2021, 3, 21),
                    Author = authors[8],
                    Category = categories[4],
                },
                new()
                {
                    Title = "Kaguya-Sama: Cuộc Chiến Tỏ Tình - Tập 16 - Tặng Kèm Ivory Card",
                    ShortDescription = "Hội trưởng Shirohgane Miyuki và hội phó Shinomiya Kaguya gặp nhau tại Hội Học Sinh của học viện Shuchiin, nơi hội tụ của những con người thuộc tầng lớp thượng lưu…",
                    Description = "Đây là câu chuyện tình cảm hài hước mới mẻ về hai thiên tài tuy trong lòng thích nhau lắm rồi những vẫn ngày ngày bày mưu tính kế cầm cưa, bắt đối phương phải tỏ tình trước. Sang tập 16, Giáng sinh đầy sóng gió đã trôi qua, kì nghỉ đông đến rồi lại đi, chớp mắt đã bước sang học kì mới!? Sau lễ hội văn hoá siêu lãng mạn, khoảng cách giữa Shirogane và Kaguya đột ngột được thu hẹp. Trong khoảng thời gian ấy, tất nhiên đã có chuyện xảy ra khiến họ càng thêm gần nhau!!!! Mặt khác, Ishigami và Iino, Fujiwara và Hayasaka bỗng cư xử thật kì cục… Hãy cùng ngược dòng thời gian, quay trở về kì nghỉ đông để biết chuyện gì đã xảy ra nhé!",
                    Meta = "Kaguya-Sama: Cuộc Chiến Tỏ Tình - Tập 16 - Tặng Kèm Ivory Card",
                    UrlSlug = "kaguya-sama-cuoc-chien-to-tinh-tap-16-tang-kem-ivory-card",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/z/4/z4285532325003_1ae1a65f7de522ec04e2651a319dbb05.jpg",
                    Supplier = "NXB Kim Đồng",
                    PublishCompany = "Kim Đồng",
                    CoverForm = "Bìa mềm",
                    StarNumber = 5,
                    ReviewNumber = 236,
                    Price = 40000,
                    ReleasedDate = new DateTime(2020, 2, 1),
                    Author = authors[9],
                    Category = categories[8],
                },
                new()
                {
                    Title = "TalMud - Tinh Hoa Trí Tuệ Do Thái (Tái Bản)",
                    ShortDescription = "Talmud là một tập hợp các văn bản cổ của các bậc thầy người Do Thái trong suốt hơn 10 thế kỷ. Bộ sách gồm 20 cuốn, hơn 1200 trang, hơn 250 vạn chữ.",
                    Description =  "Nội dung gồm ba phần “Missimah”, “Midrash” và “Germara”. Đây là nơi khởi nguồn của trí tuệ và là kim chỉ nam cho lối sống của dân tộc Do Thái.\r\n\r\nSách “Talmud” đã được dịch ra 12 thứ tiếng và được lưu truyền trên thế giới. Sở dĩ sách được sự quan tâm rộng rãi vì thể hiện được một trí tuệ, mà có thể nói người Do Thái chú trọng trí tuệ hơn bất kỳ dân tộc nào trên thế giới. Nếu có người hỏi người Do Thái: “Cái quan trọng nhất của con người là gì?”, họ nhất định sẽ trả lời: “Trí tuệ”.",
                    Meta = "TalMud - Tinh Hoa Trí Tuệ Do Thái (Tái Bản)",
                    UrlSlug = "talmud-tinh-hoa-tri-tue-do-thai",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/8/9/8935074127549_1.jpg",
                    Supplier = "Cty Văn Hóa Văn Lang",
                    PublishCompany = "Cty Văn Hóa Văn Lang",
                    CoverForm = "Bìa mềm",
                    StarNumber = 5,
                    ReviewNumber = 530,
                    Price = 110000,
                    ReleasedDate = new DateTime(2020, 4, 21),
                    Author = authors[10],
                    Category = categories[4],
                },
                new()
                {
                    Title = "Hành Trình Về Phương Đông - Bìa Cứng (Tái Bản 2021)",
                    ShortDescription = "Hành Trình Về Phương Đông, một trong những tác phẩm đương đại hay và độc đáo nhất về văn hóa phương Đông vừa tái ngộ bạn đọc trong một diện mạo hoàn toàn mới, sang trọng và ấn tượng.",
                    Description =  "Hành Trình Về Phương Đông kể về những trải nghiệm của một đoàn khoa học gồm các chuyên gia hàng đầu của Hội Khoa Học Hoàng Gia Anh được cử sang Ấn Độ nghiên cứu về huyền học và những khả năng siêu nhiên của con người. Suốt hai năm trời rong ruổi khắp các đền chùa Ấn Độ, diện kiến nhiều pháp thuật, nhiều cảnh mê tín dị đoan, thậm chí lừa đào… của nhiều pháp sư, đạo sĩ… họ được tiếp xúc với những vị chân tu thông thái sống ẩn dật ở thị trấn hay trên rặng Tuyết Sơn.",
                    Meta = "Hành Trình Về Phương Đông - Bìa Cứng (Tái Bản 2021)",
                    UrlSlug = "hanh-trinh-ve-phuong-dong-bia-cung-tai-ban-2021",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/s/f/sffffuntitled.jpg",
                    Supplier = "FIRST NEWS",
                    PublishCompany = "NXB Thế Giới",
                    CoverForm = "Bìa cứng",
                    StarNumber = 4,
                    ReviewNumber = 210,
                    Price = 138000,
                    ReleasedDate = new DateTime(2021, 12, 21),
                    Author = authors[11],
                    Category = categories[4],
                },
                //================================================5
                 new()
                {
                    Title = "Tôi Thấy Hoa Vàng Trên Cỏ Xanh (Bản In Mới - 2018)",
                    ShortDescription = "Những câu chuyện nhỏ xảy ra ở một ngôi làng nhỏ: chuyện người, chuyện cóc, chuyện ma, chuyện công chúa và hoàng tử , rồi chuyện đói ăn, cháy nhà, lụt lội,... ",
                    Description =  "Bối cảnh là trường học, nhà trong xóm, bãi tha ma. Dẫn chuyện là cậu bé 15 tuổi tên Thiều. Thiều có chú ruột là chú Đàn, có bạn thân là cô bé Mận. Nhưng nhân vật đáng yêu nhất lại là Tường, em trai Thiều, một cậu bé học không giỏi. Thiều, Tường và những đứa trẻ sống trong cùng một làng, học cùng một trường, có biết bao chuyện chung. Chúng nô đùa, cãi cọ rồi yêu thương nhau, cùng lớn lên theo năm tháng, trải qua bao sự kiện biến cố của cuộc đời.",
                    Meta = "Tôi Thấy Hoa Vàng Trên Cỏ Xanh (Bản In Mới - 2018)",
                    UrlSlug = "toi-thay-hoa-vang-tren-co-xanh-ban-in-moi-2018",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/8/9/8934974158448.jpg",
                    Supplier = "NXB Trẻ",
                    PublishCompany = "Trẻ",
                    CoverForm = "Bìa mềm",
                    StarNumber = 5,
                    ReviewNumber = 870,
                    Price = 125000,
                    ReleasedDate = new DateTime(2018, 5, 2),
                    Author = authors[0],
                    Category = categories[3],
                },
                new()
                {
                    Title = "Toán Học, Một Thiên Tiểu Thuyết",
                    ShortDescription = "Mickaël Launaykhông chỉ cho người đọc thấy cái đẹp, chất thơ của toán học mà còn xác quyết một điều khác, rằng mọi người đều có thể yêu thích toán học và đều có thể cảm nhận được vẻ đẹp tự nhiên của nó.",
                    Description = "Bởi ai mà chẳng thấy hấp dẫn với những mẩu chuyện kỳ thú về toán: như “giáo phái” toán học kỳ lạ của Pythagoras thời cổ đại hay những cuộc thăm dò hệ mặt trời bằng công cụ toán học đầy kịch tính thời cận đại, hoặc gần đây hơn là sự kiện máy tính AlphaGo giành chiến thắng trước kỳ thủ cờ vây số một thế giới Lee Sedol bằng những nước đi “thần thánh” sử dụng lý thuyết xác suất.",
                    Meta = "Toán Học, Một Thiên Tiểu Thuyết",
                    UrlSlug = "toan-hoc-mot-thien-tieu-thuyet",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/a/7/a73c3862a86bea7066d1bea6d8404baf_1.jpg",
                    Supplier = "Nhã Nam",
                    PublishCompany = "NXB Thế Giới",
                    CoverForm = "Bìa mềm",
                    StarNumber = 3,
                    ReviewNumber = 369,
                    Price = 110000,
                    ReleasedDate = new DateTime(2020, 4, 22),
                    Author = authors[12],
                    Category = categories[3],
                },
                new()
                {
                    Title = "Tự Lực Chưa Đủ, Mà Phải Tự Chủ",
                    ShortDescription = "Là con người, chúng ta có xu hướng tự nhiên là trì hoãn trước những công việc căng thẳng. Đặc biệt đứng trước những kế hoạch đòi hỏi nhiều thời gian và công sức, ta càng dễ yếu lòng mà tìm đến những thứ đem đến cảm giác vui thú tức thì",
                    Description =  "Nếu ví thành quả của những cố gắng dài hạn như món ăn thượng hạng đến từ nhà hàng cao cấp, thì những vui thú tức thì giống như món bánh kẹp McDonald vậy. Những món ăn thượng hạng chắc chắn sẽ đắt đỏ và rất tốn công để nấu nướng, nhưng hương vị đổi lại thì vô cùng xứng đáng. Ngược lại, những món ăn nhanh rất dễ làm và đem lại cảm giác thỏa mãn ngay lập tức, nhưng sẽ ngấm ngầm tổn hại đến bạn về sau.",
                    Meta = "Tự Lực Chưa Đủ, Mà Phải Tự Chủ",
                    UrlSlug = "tu-luc-chua-du-ma-phai-tu-chu",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/i/m/image_195509_1_18958.jpg",
                    Supplier = "Skybooks",
                    PublishCompany = "NXB Thế Giới",
                    CoverForm = "Bìa mềm",
                    StarNumber = 3,
                    ReviewNumber = 98,
                    Price = 63000,
                    ReleasedDate = new DateTime(2020, 4, 21),
                    Author = authors[14],
                    Category = categories[5],
                },
                 new()
                {
                    Title = "Phát Triển Tính Tự Lực Cho Trẻ (Từ Sơ Sinh Đến 6 Tuổi)",
                    ShortDescription = "Sách Phát triển tính tự lực cho trẻ từ sơ sinh đến 6 tuổi tập trung vào những khoảnh khắc các bậc cha mẹ có thể dạy trẻ tính tự lực",
                    Description =  "ới các chiến lược và phương pháp thực tiễn của bác sĩ Levine, trẻ sơ sinh sẽ học được cách ngủ ngon suốt đêm, trẻ đi chập chững sẽ có khả năng tự ăn ngon lành mà không cần đến sự dỗ dành của cha mẹ, và trẻ ở độ tuổi đi học sẽ biết cách tự mặc quần áo cũng như tự chuẩn bị đến điểm tâm với sự giúp đỡ của cha mẹ. Hãy trao cho trẻ đôi cánh để chúng tự bay thay vì bay cho chúng!",
                    Meta = "Phát Triển Tính Tự Lực Cho Trẻ (Từ Sơ Sinh Đến 6 Tuổi)",
                    UrlSlug = "phat-trien-tinh-tu-luc-cho-tre-tu-so-sinh-den-6-tuoi",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/i/m/image_134002.jpg",
                    Supplier = "Cty Văn Hóa Văn Lang",
                    PublishCompany = "NXB Thanh Hóa",
                    CoverForm = "Bìa mềm",
                    StarNumber = 4,
                    ReviewNumber = 580,
                    Price = 93000,
                    ReleasedDate = new DateTime(2020, 4, 21),
                    Author = authors[15],
                    Category = categories[7],
                },
                new()
                {
                    Title = "Tắt Đèn (Tái Bản 2020)",
                    ShortDescription = "Tắt đèn của nhà văn Ngô Tất Tố phản ánh rất chân thực cuộc sống khốn khổ của tầng lớp nông dân Việt Nam đầu thế kỷ XX dưới ách đô hộ của thực dân Pháp.",
                    Description =  "Tác phẩm xoay quanh nhân vật chị Dậu và gia đình – một điển hình của cuộc sống bần cùng hóa sưu cao thuế nặng mà chế độ thực dân áp đặt lên xã hội Việt Nam. Trong cơn cùng cực chị Dậu phải bán khoai, bán bầy chó đẻ và bán cả đứa con để lấy tiền nộp sưu thuế cho chồng nhưng cuộc sống vẫn đi vào bế tắc, không lối thoát.",
                    Meta = "Tắt Đèn (Tái Bản 2020)",
                    UrlSlug = "tat-den-tai-ban-2020",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/i/m/image_195509_1_39597.jpg",
                    Supplier = "Huy Hoang Bookstore",
                    PublishCompany = "NXB Văn Học",
                    CoverForm = "Bìa mềm",
                    StarNumber = 4,
                    ReviewNumber = 1235,
                    Price = 80000,
                    ReleasedDate = new DateTime(2020, 4, 21),
                    Author = authors[13],
                    Category = categories[0],
                },
                //================================================10
                 new()
                {
                    Title = "Truyện Tranh Ngụ Ngôn Dành Cho Thiếu Nhi: Chuột, Gà Trống Và Mèo (Song Ngữ Anh - Việt)",
                    ShortDescription = "Truyện tranh ngụ ngôn dành cho thiếu nhi ( song ngữ Anh - Việt ) là những câu chuyện nổi tiếng trong văn học dành cho thiếu nhi",
                    Description =  "Sách được thiết kế và vẽ câu chuyện theo tranh , sách được thiết kế phần tiếng anh và tiếng việt , với sự kết hợp cả hai thứ tiếng , giúp các bạn nhỏ thích thú hơn trong từng câu chuyện hay nhất được chọn lọc , bạn nhỏ có thể vừa đọc truyện tiếng anh và tiếng việt , để nâng cao phần ngoại ngữ thêm cho bé , cuối mỗi cuốn truyện đều có phần câu hỏi theo tranh cho bé thích thú hơn khi đọc xong câu chuyện, Bộ sách này có 10 chủ đề các em nhỏ tìm cho đủ tập nhé.",
                    Meta = "Truyện Tranh Ngụ Ngôn Dành Cho Thiếu Nhi: Chuột, Gà Trống Và Mèo (Song Ngữ Anh - Việt)",
                    UrlSlug = "truyen-tranh-ngu-ngon-danh-cho-thieu-nhi-chuot-ga-trong-va-meo-song-ngu-anh-viet",
                    ImageUrl = "https://cdn0.fahasa.com/media/flashmagazine/images/page_images/truyen_tranh_ngu_ngon_danh_cho_thieu_nhi_chuot__ga_trong_va_meo_song_ngu_anh___viet/2021_08_05_14_10_42_1-390x510.jpg",
                    Supplier = "MCBooks",
                    PublishCompany = "NXB Phụ Nữ Việt Nam",
                    CoverForm = "Bìa Mềm",
                    StarNumber = 4,
                    ReviewNumber = 1259,
                    Price = 29000,
                    ReleasedDate = new DateTime(2020, 8, 21),
                    Author = authors[16],
                    Category = categories[6],
                },
                new()
                {
                    Title = "Những Trò Chơi Dân Gian Phổ Thông Và Vui Nhộn Dành Cho Thiếu Nhi",
                    ShortDescription = "NHỮNG TRÒ CHƠI DÂN GIAN được người biên soạn tổng hợp và rút ra trong kho tàng trò chơi dân gian Việt Nam",
                    Description =  "Những trò chơi dân gian tiêu biểu nhất, dễ thực hiện nhất mà và chung nhất cho cả 3 miền đất nước, đây là những trò chơi dân gian mà cả 3 miền đều sử dụng. Tập sách hướng các em học sinh đến những trò chơi vui nhộn, bổ ích bằng chính sự tự lực của các em.",
                    Meta = "Những Trò Chơi Dân Gian Phổ Thông Và Vui Nhộn Dành Cho Thiếu Nhi",
                    UrlSlug = "nhung-tro-choi-dan-gian-pho-thong-va-vui-nhon-danh-cho-thieu-nhi",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/n/x/nxbtre_full_17542018_025456.jpg",
                    Supplier = "NXB Trẻ",
                    PublishCompany = "NXB Trẻ",
                    CoverForm = "Bìa Mềm",
                    StarNumber = 4,
                    ReviewNumber = 1597,
                    Price = 80000,
                    ReleasedDate = new DateTime(2023, 5, 21),
                    Author = authors[16],
                    Category = categories[6],
                },
                new()
                {
                    Title = "Truyện Ngắn Đương Đại Hàn Quốc",
                    ShortDescription = "Cuốn sách này đáng được lựa chọn với tư cách một tuyển tập tác phẩm tiêu biểu cho văn chương Hàn Quốc đương đại.",
                    Description =  "Trong văn chương đương đại Hàn Quốc, truyện ngắn là một thể loại mạnh, với sự nổi bật cũng như thành tựu quan trọng cả về số lượng lẫn chất lượng. Bởi vì tất cả 12 truyện ngắn trong này được tuyển chọn từ tạp chí Koreana, và chỉ riêng điều đó thôi đủ bảo chứng cho chúng.",
                    Meta = "Truyện Ngắn Đương Đại Hàn Quốc",
                    UrlSlug = "truyen-ngan-duong-dai-han-quoc",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/i/m/image_195509_1_4940.jpg",
                    Supplier = "NXB Văn hóa Văn nghệ",
                    PublishCompany = "NXB Văn hóa Văn nghệ",
                    CoverForm = "Bìa Mềm",
                    StarNumber = 4,
                    ReviewNumber = 910,
                    Price = 169000,
                    ReleasedDate = new DateTime(2022, 1, 21),
                    Author = authors[16],
                    Category = categories[7],
                },
                 new()
                {
                    Title = "Giáo Trình Quản Trị Chiến Lược Trong Tổ Chức Du Lịch",
                    ShortDescription = "Ngày nay, trong môi trường toàn cầu và quốc tế hóa ngày càng sâu rộng… Tất cả đã đặt các tổ chức kinh doanh, dù lớn hay nhỏ, vào một môi trường hết sức năng động.",
                    Description = "Ở nước ta, trong thời gian qua, ngành du lịch, nói chung, đã có những bước phát triển mạnh mẽ về cả số lượng các tổ chức kinh doanh cũng như chất lượng ngày càng được nâng lên. Tuy nhiên, sự phát triển trong lĩnh vực này còn cục bộ, chưa bền vững, chưa có định hướng phát triển hệ thống theo hướng chiến lược. Quản trị chiến lược là một lĩnh vực nghiên cứu còn mới mẻ, quản trị chiến lược cho các tổ chức du lịch mới được áp dụng trong một số tổ chức trên thế giới trong thời gian gần đây và đã giúp các tổ chức này thành công trong kinh doanh. Sản phẩm dịch vụ của ngành du lịch những đặc điểm rất khác biệt so với những ngành công nghiệp khác, do đó, việc áp dụng quản trị chiến lược cho các tổ chức kinh doanh du lịch là rất cần thiết trong giai đoạn hiện nay.",
                    Meta = "Giáo Trình Quản Trị Chiến Lược Trong Tổ Chức Du Lịch",
                    UrlSlug = "giao-trinh-quan-tri-chien-luoc-trong-to-chuc-du-lich",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/i/m/image_244718_1_5067.jpg",
                    Supplier = "NXB Tài Chính",
                    PublishCompany = "NXB Tài Chính",
                    CoverForm = "Bìa Mềm",
                    StarNumber = 4,
                    ReviewNumber = 1000,
                    Price = 250000,
                    ReleasedDate = new DateTime(2020, 4, 21),
                    Author = authors[17],
                    Category = categories[9],
                },
                new()
                {
                    Title = "Pháp Luật Kiểm Soát, Thảo Thuận Sử Dụng Giá - Lý Thuyết Và Thực Tiễn Tại Việt Nam",
                    ShortDescription = "Bên cạnh những lý thuyết chung về kiểm soát thỏa thuận sử dụng giá để hạn chế cạnh tranh, cuốn sách cũng tập trung trình bày, phân tích và đánh giá thực trạng pháp luật của Việt Nam",
                    Description =  "Tập trung trình bày, phân tích và đánh giá thực trạng pháp luật của Việt Nam về kiểm soát thỏa thuận sử dụng giá để hạn chế cạnh tranh, qua đó đưa ra định hướng và đề xuất các giải pháp góp phần hoàn thiện pháp luật cạnh tranh. Ngoài ra, nội dung cuốn sách cũng cập nhật những quy định mới liên quan đến pháp luật kiểm soát thỏa thuận sử dụng giá tại Việt Nam, trong đó có Luật Cạnh tranh năm 2018 và các văn bản hướng dẫn thi hành.",
                    Meta = "Pháp Luật Kiểm Soát, Thảo Thuận Sử Dụng Giá - Lý Thuyết Và Thực Tiễn Tại Việt Nam",
                    UrlSlug = "phap-luat-kiem-soat-thao-thuan-su-dung-gia-ly-thuyet-va-thuc-tien-tai-viet-nam",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/i/m/image_195509_1_37882.jpg",
                    Supplier = "NXB Chính Trị Quốc Gia",
                    PublishCompany = "NXB Chính Trị Quốc Gia",
                    CoverForm = "Bìa mềm",
                    StarNumber = 4,
                    ReviewNumber = 590,
                    Price = 68000,
                    ReleasedDate = new DateTime(2020, 4, 21),
                    Author = authors[17],
                    Category = categories[0],
                },
                //================================================15
                new()
                {
                    Title = "Tesla – Elon Musk: Tương Lai Và Những Điều Viễn Tưởng",
                    ShortDescription = "Tesla đã đến. Vào mùa thu năm 2013, công ty xuất hiện như lời gợi ý cho câu đố ô chữ trên tờ New York Times. Tên công ty đã trở thành biểu tượng cho công nghệ đột phá.",
                    Description = "Biết bao nhiêu giấy mực đã đổ vào “bí quyết” thành công của Tesla. Như chúng ta đã thấy, chẳng có bí quyết nào cả – chỉ có một ý tưởng gặp thời, một nhóm người quyết tâm cao và tài năng tuyệt đỉnh, một tí xíu may mắn cốt yếu. Câu hỏi thú vị hơn nhiều phải là: Tesla đã tạo nên những chấn động như thế nào? Và Tesla có vị trí thế nào trong lịch sử cách tân? Tất cả đều nằm trong cuốn sách “Tesla - Elon Musk: Tương lai và những điều viễn tưởng” do ThaiHaBooks ấn hành. Trong suốt 11 năm hoạt động, Tesla Motors đã gặt hái vô số thành tựu nổi bật. Công ty đã tạo ra một chiếc ô tô mà được ngay cả những ông lớn trong ngành công nghiệp xe hơi cũng phải ngả mũ thừa nhận là tốt nhất thị trường.",
                    Meta = "Tesla – Elon Musk: Tương Lai Và Những Điều Viễn Tưởng",
                    UrlSlug = "tesla-elon-musk-tuong-lai-va-nhung-dieu-vien-tuong",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/8/9/8936037710907.jpg",
                    Supplier = "Thái Hà",
                    PublishCompany = "NXB Lao Động",
                    CoverForm = "Bìa mềm",
                    StarNumber = 5,
                    ReviewNumber = 530,
                    Price = 89000,
                    ReleasedDate = new DateTime(2020, 4, 21),
                    Author = authors[18],
                    Category = categories[10],
                },
                new()
                {
                    Title = "Kinh Tế Học - Khái Lược Những Tư Tưởng Lớn (Tái Bản 2023)",
                    ShortDescription = "Kinh tế học - Khái lược những tư tưởng lớn được viết với văn phong đơn giản kèm theo các biểu đồ giải thích ngắn gọn, dễ hiểu các lí thuyết quan trọng",
                    Description =  "Điều gì xảy ra trong giai đoạn khủng hoảng kinh tế? Tiền tệ vận hành ra sao? Vì sao chúng ta phải đóng thuế? Kinh tế học ảnh hưởng đến từng khía cạnh của đời sống của chúng ta, từ việc đi làm đến cách tiêu tiền – và các ý tưởng kinh tế lớn vẫn đang tiếp tục định hình thế giới ngày nay.",
                    Meta = "Kinh Tế Học - Khái Lược Những Tư Tưởng Lớn (Tái Bản 2023)",
                    UrlSlug = "kinh-te-hoc-khai-luoc-nhung-tu-tuong-lon-tai-ban-2023",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/8/9/8936203363265.jpg",
                    Supplier = "Đông A",
                    PublishCompany = "Dân Trí",
                    CoverForm = "Bìa cứng",
                    StarNumber = 4,
                    ReviewNumber = 1230,
                    Price = 450000,
                    ReleasedDate = new DateTime(2020, 4, 21),
                    Author = authors[17],
                    Category = categories[1],
                },
                new()
                {
                    Title = "Văn Học Cổ Điển Chọn Lọc - Những Kẻ Khốn Cùng",
                    ShortDescription = "Xuyên suốt Những người khốn khổ là khúc tráng ca bi tráng mài khắc chân thật, tỉ mỉ từng linh hồn lao động khổ sai giữa nhân thế nhưng vẫn không ngừng phụng sự cái đẹp.",
                    Description =  "Nhắc đến đại văn hào Victor Hugo ắt hẳn người ta sẽ nhắc ngay đến thiên tiểu thuyết đồ sộ “Những người khốn khổ”, tác phẩm xuất sắc chiếm lĩnh văn đàn nước Pháp bất chấp sự mặc cả phù phiếm của thời gian. Tuyệt tác trên chính là sợi dây móc nối hơi ấm hôi hổi của tiểu thuyết hiện thực với tiểu thuyết xã hội, tiểu thuyết sử thi và tình yêu trên khắp nhân thế.",
                    Meta = "Văn Học Cổ Điển Chọn Lọc - Những Kẻ Khốn Cùng",
                    UrlSlug = "van-hoc-co-dien-chon-loc-nhung-ke-khon-cung",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/i/m/image_195509_1_8548.jpg",
                    Supplier = "NXB Thanh Hóa",
                    PublishCompany = "NXB Thanh Hóa",
                    CoverForm = "Bìa mềm",
                    StarNumber = 5,
                    ReviewNumber = 1250,
                    Price = 45000,
                    ReleasedDate = new DateTime(2020, 4, 21),
                    Author = authors[19],
                    Category = categories[2],
                },
                 new()
                {
                    Title = "Kể Chuyện Cuộc Đời Các Thiên Tài: Victor Hugo - Cây Đại Thụ Của Nên Văn Học Lãng Mạn Pháp",
                    ShortDescription = "Nhà thờ Đức Bà Paris và Những người khốn khổ là hai tác phẩm thành công vâng dội, góp phần đưa tên tuổi Victor Hugo trở thành tiểu thuyết gia của công chúng.",
                    Description =  "Victor Hugo, tên đầy đủ là Victor Marie Hugo, sinh ngày 26 tháng 2 năm 1802 tại Besancon, mất ngày 22 tháng 5 năm 1885 tại Paris, nước Pháp. Ông là một nhà văn, nhà thơ, nhà viết kịch theo chủ nghĩa lãng mạng nổi tiếng của nền văn chương nước Pháp. Đồng thời, ông cũng là một chính trị gia, một nhà trí thức dấn thân tiêu biểu của thế kỉ 19.",
                    Meta = "Kể Chuyện Cuộc Đời Các Thiên Tài: Victor Hugo - Cây Đại Thụ Của Nên Văn Học Lãng Mạn Pháp",
                    UrlSlug = "ke-chuyen-cuoc-doi-cac-thien-tai-victor-hugo-cay-dai-thu-cua-nen-van-hoc-lang-man-phap",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/8/9/8935210296139.jpg",
                    Supplier = "Tân Việt",
                    PublishCompany = "NXB Thanh Niên",
                    CoverForm = "Bìa mềm",
                    StarNumber = 5,
                    ReviewNumber = 980,
                    Price = 40000,
                    ReleasedDate = new DateTime(2020, 4, 21),
                    Author = authors[19],
                    Category = categories[2],
                },
                new()
                {
                    Title = "Dragon Ball Super - Tập 16: Chiến Binh Mạnh Nhất Vũ Trụ",
                    ShortDescription =  "Dragon Ball Super là loạt manga và anime truyền hình của Nhật Bản. Đây là phần tiếp theo của bộ truyện tranh Dragon Ball gốc và loạt phim hoạt hình Dragon Ball Z. ",
                    Description = "Granola là người hành tinh Cereal cuối cùng còn sống sau trận càn quét của Frieza và quân đội Saiya. Anh đã dùng ngọc rồng của hành tinh Cereal để thực hiện điều ước biến mình thành chiến binh mạnh nhất vũ trụ, trả thù cho quê hương.",
                    Meta = "Dragon Ball Super - Tập 16: Chiến Binh Mạnh Nhất Vũ Trụ",
                    UrlSlug = "dragon-ball-super-tap-16-chien-binh-manh-nhat-vu-tru",
                    ImageUrl = "https://cdn0.fahasa.com/media/catalog/product/d/r/dragon-ball-super---tap-16.jpg",
                    Supplier = "NXB Kim Đồng",
                    PublishCompany = "NXB Kim Đồng",
                    CoverForm = "Bìa mềm",
                    StarNumber = 4,
                    ReviewNumber = 390,
                    Price = 50000,
                    ReleasedDate = new DateTime(2019, 8, 21),
                    Author = authors[9],
                    Category = categories[8],
                },
                //================================================20
            };

            _dbContext.Books.AddRange(books);
            _dbContext.SaveChanges();

            return books;
        }
    }
}
