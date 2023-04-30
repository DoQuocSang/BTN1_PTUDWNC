using System;
using System.Collections.Generic;
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
                    FullName = "Dr Blair Thomas Spa",
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
                    FullName = "PGS Hà Nam Khánh Giao",
                    UrlSlug = "ha-nam-khanh",
                    Email = "hanamkhanh@gmail.com",
                    JoinedDate = new DateTime(2015, 11, 20),
                    Notes = "PGS Hà Nam Khánh Giao"
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
                new(){Name = "Tâm lý, tâm linh, tôn giáo", Description = "Là thể loại nói về các bí ẩn về tâm linh, tôn giáo", UrlSlug = "tamly-tamlinh-tongiao", ShowOnMenu = true},
                //================================================5
                
                new(){Name = "Sách tự lực", Description = "Là sách được viết với mục đích hướng dẫn độc giả giải quyết những vấn đề cá nhân. Dòng sách lấy tên từ Self-Help, " +
                 "cuốn sách bán chạy nhất năm 1859 của Samuel Smiles, nhưng còn được biết đến và phân loại theo \"tự cải thiện\", một thuật ngữ bản hiện đại hóa của tự lực", UrlSlug = "sach-tu-luc", ShowOnMenu = true},
                new(){Name = "Thiếu nhiThiếu nhi", Description = "Là những loại sách dành cho thiếu nhi", UrlSlug = "thieunhi", ShowOnMenu = true},
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
                new(){Name = "Chính trị – pháp luật", Description = "Là thể loại sách nói về pháp luật", UrlSlug = "chinhtri-phapluat"},
                new(){Name = "Kinh tế", Description = "Là thể loại sách nói về kinh tế", UrlSlug = "kinhte"},
                new(){Name = "Văn học nghệ thuật", Description = "Là thể loại văn học nghệ thuật", UrlSlug = "vanhocnghethuat"},
                new(){Name = "Tiểu thuyết", Description = "tieuthuyet", UrlSlug = "Là một thể loại văn xuôi có hư cấu"},
                new(){Name = "Tâm lý, tâm linh, tôn giáo", Description = "Là thể loại nói về các bí ẩn về tâm linh, tôn giáo", UrlSlug = "tamly-tamlinh-tongiao"},

                new(){Name = "Thiếu nhi", Description = "Là những loại sách dành cho thiếu nhi,", UrlSlug = "thieunhi"},
                new(){Name = "Truyện ngắn", Description = "Là thể loại truyện ngắn về một câu chuyện nào đó", UrlSlug = "truyenngan"},
                new(){Name = "Giáo trình", Description = "Là thể loại sách , tài liệu cụ thể, nói về các lĩnh vực nghiên cứu", UrlSlug = "giaotrinh"},
                new(){Name = "Khoa học viễn tưởng ", Description = "Là thể loại sách nói vể khoa học, nói về một vấn đề mà không có thật ở hiện tại", UrlSlug = "khoahocvientuong"},
                new(){Name = "Truyện tranh", Description = "Là thể loại về truyện tranh", UrlSlug = "truyentranh"},
            };

            _dbContext.Tags.AddRange(tags);
            _dbContext.SaveChanges();

            return tags;
        }

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
                    Description = "Câu chuyện là những trang nhật ký về cuộc sống thường ngày và tâm tư của cậu bé Thiều. Thiều đang là học sinh lớp 7 sống ở một vùng quê nghèo, cùng với người em trai tên Tường. Tường là một cậu bé dễ thương, hiền lành, bao dung, rất yêu mến anh trai và thích chơi đùa với nhiều loài động vật gồm cả sâu bọ, rắn rết." +
                    " Cậu bé sống nội tâm, ham đọc sách và rất say mê những câu chuyện cổ tích, đặc biệt là truyện Cóc tía, chính vì vậy mà cậu nuôi nấng một con cóc dưới gầm giường và đặt tên cho nó là \"Cu Cậu”.",
                    Meta = "Toi thay hoa vang tren co xanh",
                    UrlSlug = "toi-thay-hoa-vang-tren-co-xanh",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 1860,
                    Author = authors[0],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[3]
                    }
                },

                new()
                {
                    Title = "Mắt biếc",
                    ShortDescription = "Một tác phẩm được nhiều người bình chọn là hay nhất của nhà văn này. Một tác phẩm đang được dịch và giới thiệu tại Nhật Bản (theo thông tin từ các báo)…Bởi sự trong sáng của một tình cảm, bởi cái kết thúc rất, rất buồn khi suốt câu chuyện vẫn là những điều vui, buồn lẫn lộn (cái kết thúc không như mong đợi của mọi người)." +
                    " Cũng bởi, mắt biếc… năm xưa nay đâu (theo lời một bài hát).",
                    Description = "Mắt biếc xoay quanh mối tình đơn phương của Ngạn với Hà Lan, cô bạn gái có cặp mắt hút hồn nhưng cá tính bướng bỉnh. Một chuyện tình nhiều cung bậc, từ ngộ nghĩnh trẻ con, rồi tình yêu thuở học trò trong sáng, trải qua bao biến cố, trở thành một cuộc \"đuổi hình bắt bóng\" buồn da diết nhưng không nguôi hi vọng. " +
                    "Câu chuyện càng trở nên éo le hơn khi Trà Long - con gái của Hà Lan lớn lên lại nhen nhóm một tình yêu như thế với Ngạn.",
                    Meta = "Mat biec",
                    UrlSlug = "mat-biec",
                    Published = true,
                    PostedDate = new DateTime(2022, 10, 3, 11, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 200,
                    Author = authors[0],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },

                new()
                {
                    Title = "Đất rừng Phương Nam",
                    ShortDescription = " Là truyện được biết đến nhiều nhất của ông. Đây được xem là bài ca tuyệt vời về thiên nhiên và con người Nam Bộ. Cuốn tiểu thuyết kể về cuộc đời phiêu bạt của cậu bé An. " +
                    "Bối cảnh truyện diễn ra ở các tỉnh miền Tây Nam Bộ vào những năm 1945, sau khi thực dân Pháp quay trở lại xâm chiếm vùng đất này..",
                    Description = "Cậu bé An sống cùng với cha mẹ tại thành phố, sau ngày độc lập 2-9-1945. Thực dân Pháp quay trở lại xâm lược Việt Nam, đổ quân vào Nam Bộ. Pháp mở những trận đánh khiến cho những người dân sống tại các thành thị phải di tản." +
                    " An và ba má cũng phải bỏ nhà bỏ cửa để chạy giặc. Cậu nhớ đến một anh bạn đi tàu đã tặng cậu chiếc la bàn mà không kịp mang theo. Theo cha mẹ chạy hết từ vùng này tới vùng khác của miền Tây Nam Bộ. An kết bạn cùng với những đứa trẻ cùng trang lứa và có một cuộc sống tuổi thơ vùng nông thôn đầy êm đềm. " +
                    "Nhưng cứ vừa ổn định được mấy bữa thì giặc đánh tới nơi và lại phải chạy. Trong một lần mải chơi, giặc đánh đến và An đã lạc mất gia đình. Cậu trở thành đứa trẻ lang thang.",
                    Meta = "Dat rung phuong Nam",
                    UrlSlug = "dat-rung-phuong-nam",
                    Published = true,
                    PostedDate = new DateTime(2021, 1, 12, 1, 25, 0),
                    ModifiedDate = null,
                    ViewCount = 1000,
                    Author = authors[1],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },

                new()
                {
                    Title = "Đắc Nhân Tâm",
                    ShortDescription = "Là một quyển sách nhằm tự giúp bản thân (self-help) bán chạy nhất từ trước đến nay. Quyển sách này do Dale Carnegie viết và đã được xuất bản lần đầu vào năm 1936, nó đã được bán 15 triệu bản trên khắp thế giới.[1][2] Nó cũng là quyển sách bán chạy nhất của New York Times trong 10 năm." +
                    " Tác phẩm được đánh giá là cuốn sách đầu tiên và hay nhất trong thể loại này, có ảnh hưởng thay đổi cuộc đời đối với hàng triệu người trên thế giới.",
                    Description = "Quyển sách đưa ra các lời khuyên về cách thức cư xử, ứng xử và giao tiếp với mọi người để đạt được thành công trong cuộc sống (theo bản dịch của dịch giả Nguyễn Hiến Lê). Quyển sách gồm 6 phần, mỗi phần có nhiều chương.",
                    Meta = "Dac nhan tam",
                    UrlSlug = "dac-nhan-tam",
                    Published = true,
                    PostedDate = new DateTime(2020, 1, 3, 5, 23, 0),
                    ModifiedDate = null,
                    ViewCount = 569,
                    Author = authors[2],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },

                new()
                {
                    Title = "Quẳng Gánh Lo Đi Và Vui Sống",
                    ShortDescription = "Là một sách tự lực của tác giả người Mỹ Dale Carnegie, được viết vào năm 1948. Bản Việt Ngữ do Nguyễn Hiến Lê dịch năm 1955 tại Sài Gòn và đưa vào tủ sách Học làm người. " +
                    "Quyển sách này là một cẩm nang về cách làm việc và vui sống không bị lo âu.",
                    Description = "Phương cách để trị ưu phiền\r\nCách phân tích những vấn đề rắc rối[\r\nDiệt tất ưu phiền đi, đừng để nó diệt ta\r\n.",
                    Meta = "Quang ganh lo di va vui song.",
                    UrlSlug = "quang-ganh-lo-di-va-vui-song",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 1, 7, 2, 0),
                    ModifiedDate = null,
                    ViewCount = 560,
                    Author = authors[2],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[7]
                    }
                },

                //================================================5

                new()
                {
                    Title = "Tham Vọng Lớn Lao Và Quá Trình Hình Thành Đế Chế Microsoft",
                    ShortDescription = "Tham Vọng Lớn Lao Và Quá Trình Hình Thành Đế Chế Microsoft (Tái Bản 2022). Trong tiết lộ thú vị này, " +
                    "hai phóng viên điều tra Wallace và Erickson đã lần theo bước chân của Gates từ những ngày còn là một hac. Một phần doanh nhân, một phần lập dị, Gates đã trở thành nhân vật quyền.",
                    Description = "Cuốn sách này mở ra một câu chuyện sinh động và chân thực nhất về sự nổi lên của một thiên tài độc đoán, cách thức ông làm thay đổi cả một nền công nghiệp máy tính, và lý do tại sao mọi người quyết tâm tìm hiểu ông bằng được.",
                    Meta = "Tham vong lon lao va qua trinh hinh thanh de che microsoft",
                    UrlSlug = "tham-vong-lon-lao-va-qua-trinh-hinh-thanh-de-che-microsoft",
                    Published = true,
                    PostedDate = new DateTime(2020, 3, 30, 10, 45, 0),
                    ModifiedDate = null,
                    ViewCount = 800,
                    Author = authors[5],
                    Category = categories[1],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },

                new()
                {
                      Title = "Mắt biếc",
                    ShortDescription = "Một tác phẩm được nhiều người bình chọn là hay nhất của nhà văn này. Một tác phẩm đang được dịch và giới thiệu tại Nhật Bản (theo thông tin từ các báo)…Bởi sự trong sáng của một tình cảm, bởi cái kết thúc rất, rất buồn khi suốt câu chuyện vẫn là những điều vui, buồn lẫn lộn (cái kết thúc không như mong đợi của mọi người)." +
                    " Cũng bởi, mắt biếc… năm xưa nay đâu (theo lời một bài hát).",
                    Description = "Mắt biếc xoay quanh mối tình đơn phương của Ngạn với Hà Lan, cô bạn gái có cặp mắt hút hồn nhưng cá tính bướng bỉnh. Một chuyện tình nhiều cung bậc, từ ngộ nghĩnh trẻ con, rồi tình yêu thuở học trò trong sáng, trải qua bao biến cố, trở thành một cuộc \"đuổi hình bắt bóng\" buồn da diết nhưng không nguôi hi vọng. " +
                    "Câu chuyện càng trở nên éo le hơn khi Trà Long - con gái của Hà Lan lớn lên lại nhen nhóm một tình yêu như thế với Ngạn.",
                    Meta = "Mat biec",
                    UrlSlug = "mat-biec",
                    Published = true,
                    PostedDate = new DateTime(2022, 10, 3, 11, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 200,
                    Author = authors[0],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },

                new()
                {   Title = "Mắt biếc",
                    ShortDescription = "Một tác phẩm được nhiều người bình chọn là hay nhất của nhà văn này. Một tác phẩm đang được dịch và giới thiệu tại Nhật Bản (theo thông tin từ các báo)…Bởi sự trong sáng của một tình cảm, bởi cái kết thúc rất, rất buồn khi suốt câu chuyện vẫn là những điều vui, buồn lẫn lộn (cái kết thúc không như mong đợi của mọi người)." +
                    " Cũng bởi, mắt biếc… năm xưa nay đâu (theo lời một bài hát).",
                    Description = "Mắt biếc xoay quanh mối tình đơn phương của Ngạn với Hà Lan, cô bạn gái có cặp mắt hút hồn nhưng cá tính bướng bỉnh. Một chuyện tình nhiều cung bậc, từ ngộ nghĩnh trẻ con, rồi tình yêu thuở học trò trong sáng, trải qua bao biến cố, trở thành một cuộc \"đuổi hình bắt bóng\" buồn da diết nhưng không nguôi hi vọng. " +
                    "Câu chuyện càng trở nên éo le hơn khi Trà Long - con gái của Hà Lan lớn lên lại nhen nhóm một tình yêu như thế với Ngạn.",
                    Meta = "Mat biec",
                    UrlSlug = "mat-biec",
                    Published = true,
                    PostedDate = new DateTime(2022, 10, 3, 11, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 200,
                    Author = authors[0],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },

                new()
                {
                      Title = "Mắt biếc",
                    ShortDescription = "Một tác phẩm được nhiều người bình chọn là hay nhất của nhà văn này. Một tác phẩm đang được dịch và giới thiệu tại Nhật Bản (theo thông tin từ các báo)…Bởi sự trong sáng của một tình cảm, bởi cái kết thúc rất, rất buồn khi suốt câu chuyện vẫn là những điều vui, buồn lẫn lộn (cái kết thúc không như mong đợi của mọi người)." +
                    " Cũng bởi, mắt biếc… năm xưa nay đâu (theo lời một bài hát).",
                    Description = "Mắt biếc xoay quanh mối tình đơn phương của Ngạn với Hà Lan, cô bạn gái có cặp mắt hút hồn nhưng cá tính bướng bỉnh. Một chuyện tình nhiều cung bậc, từ ngộ nghĩnh trẻ con, rồi tình yêu thuở học trò trong sáng, trải qua bao biến cố, trở thành một cuộc \"đuổi hình bắt bóng\" buồn da diết nhưng không nguôi hi vọng. " +
                    "Câu chuyện càng trở nên éo le hơn khi Trà Long - con gái của Hà Lan lớn lên lại nhen nhóm một tình yêu như thế với Ngạn.",
                    Meta = "Mat biec",
                    UrlSlug = "mat-biec",
                    Published = true,
                    PostedDate = new DateTime(2022, 10, 3, 11, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 200,
                    Author = authors[0],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },


                //================================================10

                new()
                {
                    Title = "Chiêu Bài Quản Lý Vàng Của Bill Gates ",
                    ShortDescription = "Chiêu Bài Quản Lý Vàng Của Bill Gates sẽ giải thích tại sao Bill Gates lại thành công đến vậy? Tại sao lịch sử lại chọn ông? Là một nhà lãnh đạo, Bill Gates đã có những phương pháp quản lý như thế nào để Microsoft không ngừng phát triển?",
                    Description = "Chiêu Bài Quản Lý Vàng Của Bill Gates sẽ giải thích tại sao Bill Gates lại thành công đến vậy? Tại sao lịch sử lại chọn ông? Là một nhà lãnh đạo, Bill Gates đã có những phương pháp quản lý như thế nào để Microsoft không ngừng phát triển",
                    Meta = "Chieu bai quan ly vang cua bill gates",
                    UrlSlug = "chieu-bai-quan-ly-vang-cua-bill-gates",
                    Published = true,
                    PostedDate = new DateTime(2021, 8, 10, 8, 30, 0),
                    ModifiedDate = null,
                    ViewCount = 995,
                    Author = authors[1],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[9]
                    }
                }
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
                    Description =  "Đây là câu chuyện tình cảm hài hước mới mẻ về hai thiên tài tuy trong lòng thích nhau lắm rồi những vẫn ngày ngày bày mưu tính kế cầm cưa, bắt đối phương phải tỏ tình trước.\r\n\r\nSang tập 16, Giáng sinh đầy sóng gió đã trôi qua, kì nghỉ đông đến rồi lại đi, chớp mắt đã bước sang học kì mới!? Sau lễ hội văn hoá siêu lãng mạn, khoảng cách giữa Shirogane và Kaguya đột ngột được thu hẹp. Trong khoảng thời gian ấy, tất nhiên đã có chuyện xảy ra khiến họ càng thêm gần nhau!!!!\r\n\r\nMặt khác, Ishigami và Iino, Fujiwara và Hayasaka bỗng cư xử thật kì cục…\r\n\r\nHãy cùng ngược dòng thời gian, quay trở về kì nghỉ đông để biết chuyện gì đã xảy ra nhé!\r\n\r\n“Trong tình yêu, ai tỏ tình trước là kẻ thua cuộc!”\r\n\r\n“Người ta nói, tình yêu chỉ thú vị khi chưa tiến vào giai đoạn hẹn hò.”\r\n\r\nMã hàng\t8935244887921\r\nĐộ Tuổi\t17+\r\nTên Nhà Cung Cấp\tNhà Xuất Bản Kim Đồng\r\nTác giả\tAka Akasaka\r\nNgười Dịch\tDĩ Ninh\r\nNXB\tKim Đồng\r\nNăm XB\t2023\r\nNgôn Ngữ\tTiếng Việt\r\nTrọng lượng (gr)\t210\r\nKích Thước Bao Bì\t18 x 13 x 1 cm\r\nSố trang\t204\r\nHình thức\tBìa Mềm\r\nSản phẩm bán chạy nhất\tTop 100 sản phẩm Manga Khác bán chạy của tháng\r\nGiá sản phẩm trên Fahasa.com đã bao gồm thuế theo luật hiện hành. Bên cạnh đó, tuỳ vào loại sản phẩm, hình thức và địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như Phụ phí đóng gói, phí vận chuyển, phụ phí hàng cồng kềnh,...\r\nKaguya-Sama: Cuộc Chiến Tỏ Tình - Tập 16\r\n\r\nHội trưởng Shirohgane Miyuki và hội phó Shinomiya Kaguya gặp nhau tại Hội Học Sinh của học viện Shuchiin, nơi hội tụ của những con người thuộc tầng lớp thượng lưu…\r\n\r\nĐây là câu chuyện tình cảm hài hước mới mẻ về hai thiên tài tuy trong lòng thích nhau lắm rồi những vẫn ngày ngày bày mưu tính kế cầm cưa, bắt đối phương phải tỏ tình trước.\r\n\r\nSang tập 16, Giáng sinh đầy sóng gió đã trôi qua, kì nghỉ đông đến rồi lại đi, chớp mắt đã bước sang học kì mới!? Sau lễ hội văn hoá siêu lãng mạn, khoảng cách giữa Shirogane và Kaguya đột ngột được thu hẹp. Trong khoảng thời gian ấy, tất nhiên đã có chuyện xảy ra khiến họ càng thêm gần nhau!!!!",
                    Meta = "Kaguya-Sama: Cuộc Chiến Tỏ Tình - Tập 16 - Tặng Kèm Ivory Card",
                    UrlSlug = "kaguya-sama-cuoc chien-to-tinh-tap-16",
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
                    ImageUrl = "https://cdn0.fahasa.com/media/wysiwyg/hieu_kd/2023_04_frame/FRAME_NCC_FRAME_T42023_SLIVER_NCC_MCBOOK.png",
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
                    Description =  "Ở nước ta, trong thời gian qua, ngành du lịch, nói chung, đã có những bước phát triển mạnh mẽ về cả số lượng các tổ chức kinh doanh cũng như chất lượng ngày càng được nâng lên. Tuy nhiên, sự phát triển trong lĩnh vực này còn cục bộ, chưa bền vững, chưa có định hướng phát triển hệ thống theo hướng chiến lược. Quản trị chiến lược là một lĩnh vực nghiên cứu còn mới mẻ, quản trị chiến lược cho các tổ chức du lịch mới được áp dụng trong một số tổ chức trên thế giới trong thời gian gần đây và đã giúp các tổ chức này thành công trong kinh doanh. Sản phẩm dịch vụ của ngành du lịch những đặc điểm rất khác biệt so với những ngành công nghiệp khác, do đó, việc áp dụng quản trị chiến lược cho các tổ chức kinh doanh du lịch là rất cần thiết trong giai đoạn hiện nay. Điểm khác biệt cơ bản của quản trị chiến lược cho các tổ chức sản xuất và quản trị chiến lược cho tổ chức du lịch chính là do đặc điểm kinh doanh của ngành du lịch so với những ngành công nghiệp khác.\r\n\r\nGiáo trình này được xây dựng trên cơ sở sử dụng lý thuyết chung về quản trị chiến lược, nhưng được áp dụng một cách thích nghi vào ngành du lịch, cụ thể bằng cách nhấn mạnh những điểm quan trọng ảnh hưởng đến du lịch thông qua những minh họa về một số hoạt động của các tổ chức du lịch. Hiện nay, có rất nhiều giáo trình trong nước và trên thế giới viết về quản trị chiến lược. Tuy nhiên, có rất ít giáo trình áp dụng quan niệm quản trị chiến lược vào bối cảnh dịch vụ, đặc biệt là đối với ngành du lịch. Giáo trình quản trị chiến lược cho tổ chức du lịch ra đời nhằm giúp cho sinh viên các ngành du lịch, lữ hành, khách sạn, nhà hàng có thêm tài liệu học tập và hiểu một cách sâu sắc hơn về những vấn đề cơ bản, những yếu tố liên quan trong quản trị chiến lược nói chung và áp dụng quản trị chiến lược hiệu quả đối với ngành du lịch thông qua thực tế và đặc điểm hoạt động của ngành du lịch. Giáo trình cũng giúp các nhà kinh doanh trong lãnh vực này cơ sở để tìm kiếm những giải pháp chiến lược hiệu quả để duy trì lợi thế cạnh tranh, phát triển hoạt động kinh doanh.\r\n\r\nĐỐI TƯỢNG, NỘI DUNG, PHƯƠNG PHÁP NGHIÊN CỨU MÔN HỌC\r\n\r\nĐối tượng nghiên cứu môn học là chiến lược cho các tổ chức du lịch gồm: du lịch, lữ hành, khách sạn, nhà hàng.\r\n\r\nNội dung nghiên cứu của môn học:\r\n\r\n- Các khái niệm cơ bản về chiến lược, quản trị chiến lược trong tổ chức du lịch.\r\n\r\n- Phân tích các yếu tố bên trong, bên ngoài có ảnh hưởng đến chiến lược của tổ chức du lịch.\r\n\r\n- Xây dựng, đánh giá và lựa chọn chiến lược cho tổ chức du lịch.\r\n\r\n- Thực thi chiến lược.\r\n\r\n- Kiểm tra và điều chỉnh chiến lược.\r\n\r\n- Chiến lược du lịch trong môi trường toàn cầu.\r\n\r\nPhương pháp sử dụng nghiên cứu môn học là phương pháp duy vật biện chứng và duy vật lịch sử.\r\n\r\nMã hàng\t9786047927982\r\nNhà Cung Cấp\tCÔNG TY TNHH THƯƠNG MẠI DỊCH VỤ QUẢNG CÁO NHÀ SÁCH KINH TẾ\r\nTác giả\tPGS Hà Nam Khánh Giao, TS Lê Thái Sơn, ThS Huỳnh Quốc Tuấn\r\nNXB\tNXB Tài Chính\r\nNăm XB\t2021\r\nTrọng lượng (gr)\t484\r\nKích Thước Bao Bì\t24 x 16 x 1.6 cm\r\nSố trang\t373\r\nHình thức\tBìa Mềm\r\nSản phẩm bán chạy nhất\tTop 100 sản phẩm Đại học bán chạy của tháng\r\nGiá sản phẩm trên Fahasa.com đã bao gồm thuế theo luật hiện hành. Bên cạnh đó, tuỳ vào loại sản phẩm, hình thức và địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như Phụ phí đóng gói, phí vận chuyển, phụ phí hàng cồng kềnh,...\r\nGiáo Trình Quản Trị Chiến Lược Trong Tổ Chức Du Lịch\r\n\r\nNgày nay, trong môi trường toàn cầu và quốc tế hóa ngày càng sâu rộng… Tất cả đã đặt các tổ chức kinh doanh, dù lớn hay nhỏ, vào một môi trường hết sức năng động. Trong môi trường ấy, một câu hỏi được đặt ra: tại sao có tổ chức lại thành công, trong khi một số tổ chức khác lại thất bại? Làm thế nào để tăng cơ hội thành công nhằm duy trì lợi thế cạnh tranh bền vững. Công nghiệp dịch vụ cũng không nằm ngoài bối cảnh này, nhất là dịch vụ du lịch. Tỷ trọng của các ngành công nghiệp dịch vụ trong GDP của một quốc gia ngày càng được chú trọng và chuyển dịch theo hướng tăng cao hơn và đóng góp ngày càng nhiều hơn cho sự phát triển của nền kinh tế.\r\n\r\nỞ nước ta, trong thời gian qua, ngành du lịch, nói chung, đã có những bước phát triển mạnh mẽ về cả số lượng các tổ chức kinh doanh cũng như chất lượng ngày càng được nâng lên. Tuy nhiên, sự phát triển trong lĩnh vực này còn cục bộ, chưa bền vững, chưa có định hướng phát triển hệ thống theo hướng chiến lược.",
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
                    Description =  "Biết bao nhiêu giấy mực đã đổ vào “bí quyết” thành công của Tesla. Như chúng ta đã thấy, chẳng có bí quyết nào cả – chỉ có một ý tưởng gặp thời, một nhóm người quyết tâm cao và tài năng tuyệt đỉnh, một tí xíu may mắn cốt yếu. Câu hỏi thú vị hơn nhiều phải là: Tesla đã tạo nên những chấn động như thế nào? Và Tesla có vị trí thế nào trong lịch sử cách tân? Tất cả đều nằm trong cuốn sách “Tesla - Elon Musk: Tương lai và những điều viễn tưởng” do ThaiHaBooks ấn hành.\r\n\r\nTrong suốt 11 năm hoạt động, Tesla Motors đã gặt hái vô số thành tựu nổi bật. Công ty đã tạo ra một chiếc ô tô mà được ngay cả những ông lớn trong ngành công nghiệp xe hơi cũng phải ngả mũ thừa nhận là tốt nhất thị trường. Hiệu suất của Tesla Model S có thể sánh ngang với những chiếc sedan xa xỉ đáng ngưỡng mộ bậc nhất, ngay cả khi nó không phải là một chiếc xe chạy bằng xăng. Công ty đã đứng vững, và thậm chí còn thu được lợi nhuận, trong một ngành công nghiệp, nói nhẹ nhàng nhất là, không có chỗ cho những kẻ mới bắt đầu kinh doanh. Không chỉ làm thay đổi nhận thức của công chúng về xe điện mà quan trọng hơn cả, Tesla Motor đã trở thành động lực khiến nhiều ông lớn trong ngành công nghiệp xe hơi phải đổ công sức gấp đôi vào lĩnh vực điện khí hóa. Một ngày nào đó, Tesla có phá sản (chắc nhiều người sẽ rất vui nếu điều đó thực sự xảy ra), thì công ty vẫn có cho mình một chỗ đứng trong biên niên sử của cả ngành Kinh tế và Công nghệ.\r\n\r\nVới việc đưa hoạt động giao dịch ô tô vào kỉ nguyên số, Tesla cũng thúc ép tăng tốc quá trình đổi mới trong ngành. Tác giả cuốn sách này, xuất thân là người có nền tảng Internet, và thậm chí sau khi đã có vài năm kinh nghiệm viết về ô tô, vẫn không quen được với tốc độ tiến bộ tương đối ảm đạm của ngành ô tô. Mãi cho tới gần đây, kiến thức phổ biến trong ngành này vẫn là phải mất khoảng mười năm từ khi có ý tưởng về một mẫu xe mới cho tới ngày nó thực sự có mặt ở các đại lý bán hàng.\r\n\r\n“Tesla – Elon Musk: Tương lai và những điều viễn tưởng” là cuộc hành trình của một gã tí hon lặn ngụp trong cuộc chơi của những gã khổng, và trở thành một cái tên mà bất kì gã khổng lồ cũng phải e ngại.\r\n\r\nMã hàng\t8936037710907\r\nTên Nhà Cung Cấp\tThái Hà\r\nTác giả\tCharles Morris\r\nNgười Dịch\tQuốc Đạt\r\nNXB\tNXB Lao Động\r\nNăm XB\t2018\r\nTrọng lượng (gr)\t350\r\nKích Thước Bao Bì\t15.5 x 24 x 1.5\r\nSố trang\t310\r\nHình thức\tBìa Mềm\r\nSản phẩm hiển thị trong\t\r\nELON MUSK\r\nSản phẩm bán chạy nhất\tTop 100 sản phẩm Khoa học khác bán chạy của tháng\r\nGiá sản phẩm trên Fahasa.com đã bao gồm thuế theo luật hiện hành. Bên cạnh đó, tuỳ vào loại sản phẩm, hình thức và địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như Phụ phí đóng gói, phí vận chuyển, phụ phí hàng cồng kềnh,...\r\n \r\n\r\nTESLA – ELON MUSK\r\n\r\nTƯƠNG LAI VÀ NHỮNG ĐIỀU VIỄN TƯỞNG\r\n\r\nTesla đã đến. Vào mùa thu năm 2013, công ty xuất hiện như lời gợi ý cho câu đố ô chữ trên tờ New York Times. Tên công ty đã trở thành biểu tượng cho công nghệ đột phá. Biết bao nhiêu giấy mực đã đổ vào “bí quyết” thành công của Tesla. Như chúng ta đã thấy, chẳng có bí quyết nào cả – chỉ có một ý tưởng gặp thời, một nhóm người quyết tâm cao và tài năng tuyệt đỉnh, một tí xíu may mắn cốt yếu. Câu hỏi thú vị hơn nhiều phải là: Tesla đã tạo nên những chấn động như thế nào?",
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
