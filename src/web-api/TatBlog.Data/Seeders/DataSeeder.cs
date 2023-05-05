using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;

namespace TatBlog.Data.Seeders
{
    // Tạo Migration
    // Add-Migration InitialCreate
    //Cập nhật Database
    //Update-Database -Verbose


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
                }
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
                 new(){Name = "Sách tự lực", Description = "Là sách được viết với mục đích hướng dẫn độc giả giải quyết những vấn đề cá nhân. Dòng sách lấy tên từ Self-Help, " +
                 "cuốn sách bán chạy nhất năm 1859 của Samuel Smiles, nhưng còn được biết đến và phân loại theo \"tự cải thiện\", một thuật ngữ bản hiện đại hóa của tự lực", UrlSlug = "sach-tu-luc", ShowOnMenu = true},

                new(){Name = "Thiếu nhiThiếu nhi", Description = "Là những loại sách dành cho thiếu nhi", UrlSlug = "thieunhi", ShowOnMenu = true},
                new(){Name = "Truyện ngắn", Description = "Là thể loại truyện ngắn về một câu chuyện nào đó", UrlSlug = "truyenngan", ShowOnMenu = true},
                new(){Name = "Truyện tranh", Description = "Là thể loại về truyện tranh", UrlSlug = "truyentranh", ShowOnMenu = true},
                new(){Name = "Giáo trình", Description = "Là thể loại sách , tài liệu cụ thể, nói về các lĩnh vực nghiên cứu", UrlSlug = "giaotrinhgiaotrinh", ShowOnMenu = true},
                new(){Name = "Khoa học viễn tưởng", Description = "Là thể loại sách nói vể khoa học, nói về một vấn đề mà không có thật ở hiện tại", UrlSlug = "khoahocvientuong", ShowOnMenu = true}
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
                
                new(){Name = "Thiếu nhiThiếu nhi", Description = "Là những loại sách dành cho thiếu nhi,", UrlSlug = "thieunhi"},
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
                        tags[10]
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
                        tags[19]
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
                        tags[10]
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
                        tags[13]
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
                        tags[10]
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
                        tags[10]
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
                        tags[10]
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
                },

               

                new()
                {
                    Title = "Aenean sit amet ornare est. Maecenas a purus",
                    ShortDescription = "Aenean sit amet ornare est. Maecenas a purus quis ante tempor maximus. In a fermentum leo, et convallis nunc.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis sodales sapien vitae nunc posuere varius. Donec ligula tellus, congue in quam vitae, aliquam facilisis dui. Ut ac ipsum in est consequat dapibus. Fusce blandit cursus urna ac tincidunt. In efficitur orci in augue lobortis, sed accumsan neque pulvinar. Phasellus elementum eros urna, id pellentesque purus ornare cursus. In semper feugiat eros, non commodo risus rutrum sagittis. Etiam vel ex ac ante placerat elementum vitae eu dui.",
                    Meta = "Aenean sit amet ornare est. Maecenas a purus quis ante tempor maximus. In a fermentum leo, et convallis nunc.",
                    UrlSlug = "aenean-sit-amet-ornare-est-maecenas-a-purus",
                    Published = true,
                    PostedDate = new DateTime(2020, 9, 27, 5, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 659,
                    Author = authors[4],
                    Category = categories[8],
                    Tags = new List<Tag>()
                    {
                        tags[8]
                    }
                },

                new()
                {
                    Title = "Aliquam ut nunc convallis, porttitor nulla sit amet",
                    ShortDescription = "Mauris porta quis erat sed suscipit. Curabitur sodales egestas felis, vel pellentesque urna.",
                    Description = "onec augue mauris, gravida quis tempor id, porttitor id ante. Praesent vitae leo accumsan, efficitur augue vel, gravida sapien. Aenean sit amet ante eu elit blandit placerat. Duis finibus nibh vitae est tincidunt consequat. Duis a elementum felis. Nulla blandit quis nisi ut porta.",
                    Meta = "Mauris porta quis erat sed suscipit. Curabitur sodales egestas felis, vel pellentesque urna.",
                    UrlSlug = "aliquam-ut-nunc-convallis-porttitor-nulla-sit-amet",
                    Published = true,
                    PostedDate = new DateTime(2023, 1, 1, 1, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 100,
                    Author = authors[4],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[0]
                    }
                },

                new()
                {
                    Title = "Morbi eget leo auctor, semper ipsum euismod",
                    ShortDescription = "Donec eget turpis et libero fringilla semper vel eget magna. Nulla blandit justo ut libero vehicula, non commodo urna consequat",
                    Description = "Ut interdum augue sit amet lorem congue convallis. Vestibulum ut hendrerit augue. Sed non luctus sapien, posuere scelerisque ante. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Cras tempor nibh erat, sed pellentesque mauris posuere id. Mauris volutpat laoreet urna, sed porta nisi auctor eget.\r\n\r\nNam et ornare neque. Vestibulum sodales egestas massa, sed lobortis neque finibus in. Proin in purus eros. Curabitur et fermentum dui. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur accumsan est quis diam sodales aliquam. Sed commodo nisl quis massa sollicitudin, vitae pretium ex tincidunt. Aenean efficitur porttitor faucibus. Curabitur tempus nulla id est aliquam, quis tristique arcu gravida. Etiam molestie neque elit, ac posuere tellus posuere dapibus. Curabitur maximus elementum nunc, eu vulputate mauris vulputate et. Aliquam interdum, mauris sed condimentum congue, enim quam porttitor felis, a molestie nulla eros vitae diam. Sed massa urna, finibus lobortis lacus at, consectetur faucibus turpis. Praesent ipsum mi, placerat sed aliquet vitae, sagittis in ante. Ut vehicula non nibh vel rhoncus. Nam elementum, nulla non ullamcorper iaculis, nibh lectus molestie diam, at sagittis nulla odio id lacus.\r\n\r\nVivamus egestas nec metus eu suscipit. Aliquam lorem nulla, hendrerit at nisi quis, consectetur hendrerit purus. Donec quis sodales nunc. Curabitur fringilla leo et quam lacinia, a finibus nisi aliquam. Proin pharetra dignissim leo, non fringilla diam ultrices non. Aliquam finibus augue at euismod porta. Donec congue velit sodales risus malesuada consequat. Cras bibendum, ante eget luctus rutrum, libero magna bibendum quam, ac semper enim velit eget velit. Ut massa felis, condimentum sit amet turpis in, porta vulputate enim. Vivamus tempus ante vitae elit varius, quis feugiat magna elementum. Sed sit amet hendrerit erat. Donec ac risus vel quam auctor tincidunt. Suspendisse condimentum, nulla a tristique bibendum, lectus felis scelerisque tellus, in convallis leo orci non turpis. Quisque sit amet congue diam. Aenean tristique purus tortor, ut condimentum dolor finibus aliquet.",
                    Meta = "Donec eget turpis et libero fringilla semper vel eget magna. Nulla blandit justo ut libero vehicula, non commodo urna consequat",
                    UrlSlug = "morbi-eget-leo-auctor-semper-ipsum-euismod",
                    Published = true,
                    PostedDate = new DateTime(2020, 1, 20, 11, 56, 0),
                    ModifiedDate = null,
                    ViewCount = 100,
                    Author = authors[4],
                    Category = categories[2],
                    Tags = new List<Tag>()
                    {
                        tags[6]
                    }
                },

                //================================================


                new()
                {
                    Title = "Suspendisse luctus interdum tellus",
                    ShortDescription = "Nullam rutrum turpis pulvinar dolor suscipit, a elementum tortor pulvinar. Suspendisse vitae gravida ipsum.",
                    Description = "Aenean aliquam magna eget varius tincidunt. Ut quis congue nibh. Praesent pharetra tortor nunc, ac scelerisque velit ullamcorper sed. Nullam at facilisis erat. Praesent eget ullamcorper quam. Phasellus mollis lacinia velit, et viverra magna euismod sit amet. Vivamus rhoncus, orci ut mattis gravida, lorem augue ornare mi, nec sagittis turpis leo sed ipsum.\r\n\r\nVivamus rhoncus nec risus in accumsan. Vivamus sed tortor porta, semper nibh in, suscipit quam. Cras sodales, erat quis aliquet mattis, nibh metus tincidunt risus, eget tincidunt urna quam eget odio. Morbi pulvinar nisl nibh, et tempus nunc vestibulum facilisis. Sed tincidunt ullamcorper suscipit. Aenean auctor nunc non blandit ultrices. Phasellus sagittis est ut enim volutpat, sed molestie mi scelerisque. Suspendisse nisi ex, efficitur eget imperdiet facilisis, faucibus vitae lorem. Donec at dui urna. Vestibulum congue fermentum posuere. Quisque mattis vestibulum purus id molestie. Integer congue ipsum ac augue interdum, imperdiet elementum metus pharetra. Donec venenatis pulvinar lacus. Aenean imperdiet eu lectus vel consequat. Quisque faucibus arcu et volutpat iaculis. Nulla hendrerit lacinia nisi, non pulvinar nunc convallis quis.",
                    Meta = "Nullam rutrum turpis pulvinar dolor suscipit, a elementum tortor pulvinar. Suspendisse vitae gravida ipsum.",
                    UrlSlug = "suspendisse-luctus-interdum-tellus",
                    Published = true,
                    PostedDate = new DateTime(2019, 7, 3, 1, 45, 0),
                    ModifiedDate = null,
                    ViewCount = 460,
                    Author = authors[5],
                    Category = categories[1],
                    Tags = new List<Tag>()
                    {
                        tags[17]
                    }
                },

                new()
                {
                    Title = "Vivamus dictum sodales commodo",
                    ShortDescription = "Phasellus consequat enim vitae justo finibus rhoncus. Maecenas enim est",
                    Description = "Donec accumsan maximus lacus, vel consectetur dolor molestie sed. Phasellus eu auctor elit, vitae tempor tellus. Nullam lobortis neque semper leo convallis aliquet. Sed non ipsum quis felis varius suscipit et non odio.\r\n\r\nNullam tempor eros nisl, vitae volutpat dui fermentum sed. Integer convallis ac lorem in suscipit. Sed fringilla mi ligula, eu finibus dui hendrerit vitae. Morbi scelerisque erat ut tortor posuere eleifend. Nullam eu auctor diam. Integer vitae tortor lectus. Aenean rutrum euismod mauris id dictum. Aliquam erat volutpat. Proin sed mi non velit scelerisque egestas. Nullam vehicula tellus ante, sit amet ornare diam convallis id. In hac habitasse platea dictumst. Aliquam mollis fringilla dolor et scelerisque.",
                    Meta = "Phasellus consequat enim vitae justo finibus rhoncus. Maecenas enim est",
                    UrlSlug = "vivamus-dictum-sodales-commodo",
                    Published = true,
                    PostedDate = new DateTime(2021, 5, 8, 8, 11, 0),
                    ModifiedDate = null,
                    ViewCount = 145,
                    Author = authors[5],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[11]
                    }
                },

                new()
                {
                    Title = "Vestibulum consequat lacus varius",
                    ShortDescription = "Donec accumsan maximus lacus, vel consectetur dolor molestie sed. Phasellus eu auctor elit, vitae tempor tellus. Nullam lobortis neque semper leo convallis aliquet. Sed non ipsum quis felis varius suscipit et non odio.\r\n\r\nNullam tempor eros nisl, vitae volutpat dui fermentum sed. Integer convallis ac lorem in suscipit. Sed fringilla mi ligula, eu finibus dui hendrerit vitae. Morbi scelerisque erat ut tortor posuere eleifend. Nullam eu auctor diam. Integer vitae tortor lectus. Aenean rutrum euismod mauris id dictum. Aliquam erat volutpat. Proin sed mi non velit scelerisque egestas. Nullam vehicula tellus ante, sit amet ornare diam convallis id. In hac habitasse platea dictumst. Aliquam mollis fringilla dolor et scelerisque.",
                    Description = "Curabitur et diam quis orci efficitur congue. Aliquam interdum consectetur consequat. Phasellus consequat augue bibendum, gravida risus nec, consectetur augue. In sed odio venenatis, tempor magna sit amet, dapibus ex. Aenean lobortis non neque quis ultricies. Integer venenatis magna a scelerisque finibus. Praesent tempor, nunc vitae tempor porttitor, erat justo mattis erat, quis consequat purus ligula ac est. Quisque efficitur aliquam dui eget laoreet. Mauris elit ligula, ullamcorper in elementum consequat, sodales non leo. Vivamus in ante eu mauris varius tincidunt. Quisque tincidunt justo ac cursus posuere.\r\n\r\nFusce ac mi sit amet nibh posuere dignissim ut quis ante. Morbi vehicula elit velit. Sed maximus a turpis eu condimentum. Ut tincidunt pulvinar tellus eu aliquet. Donec consequat felis id quam viverra tempor. Ut vitae augue in elit maximus porttitor. Curabitur id ligula in ante semper lacinia. Mauris ac ipsum sed massa fermentum feugiat. Pellentesque eleifend sapien sit amet nibh fermentum, at vehicula augue facilisis.",
                    Meta = "Donec accumsan maximus lacus, vel consectetur dolor molestie sed. Phasellus eu auctor elit, vitae tempor tellus. Nullam lobortis neque semper leo convallis aliquet. Sed non ipsum quis felis varius suscipit et non odio.\r\n\r\nNullam tempor eros nisl, vitae volutpat dui fermentum sed. Integer convallis ac lorem in suscipit. Sed fringilla mi ligula, eu finibus dui hendrerit vitae. Morbi scelerisque erat ut tortor posuere eleifend. Nullam eu auctor diam. Integer vitae tortor lectus. Aenean rutrum euismod mauris id dictum. Aliquam erat volutpat. Proin sed mi non velit scelerisque egestas. Nullam vehicula tellus ante, sit amet ornare diam convallis id. In hac habitasse platea dictumst. Aliquam mollis fringilla dolor et scelerisque.",
                    UrlSlug = "vestibulum-consequat-lacus-varius",
                    Published = true,
                    PostedDate = new DateTime(2020, 7, 3, 6, 19, 0),
                    ModifiedDate = null,
                    ViewCount = 560,
                    Author = authors[5],
                    Category = categories[7],
                    Tags = new List<Tag>()
                    {
                        tags[16]
                    }
                },

                new()
                {
                    Title = "Praesent id augue nibh. Maecenas vitae accumsan urna",
                    ShortDescription = "Mauris semper ullamcorper enim sit amet mattis. Donec felis lacus, tincidunt sit amet felis vel, sagittis venenatis urna.",
                    Description = "Curabitur sit amet lorem nibh. Donec eu enim libero. Mauris nec dapibus lacus. Proin commodo sagittis sem euismod aliquet. Donec semper magna in est viverra, ac maximus nunc dapibus. Etiam sollicitudin viverra luctus. Phasellus venenatis, magna malesuada bibendum ultricies, tellus eros posuere massa, sit amet varius quam risus id est. Aenean blandit lorem non elementum consectetur. Mauris interdum massa ante, non eleifend purus pulvinar lobortis. Donec ullamcorper quis nibh id hendrerit. Sed a malesuada diam, in hendrerit erat.\r\n\r\nCras auctor porttitor tortor in varius. Integer vestibulum ex eu ligula malesuada euismod. Fusce nec laoreet arcu. Sed elementum velit id fermentum vehicula. Morbi eu rutrum elit. Pellentesque fermentum bibendum tellus nec rhoncus. Suspendisse scelerisque eu dui aliquam pretium.",
                    Meta = "Mauris semper ullamcorper enim sit amet mattis. Donec felis lacus, tincidunt sit amet felis vel, sagittis venenatis urna.",
                    UrlSlug = "praesent-id-augue-nibh-maecenas-vitae-accumsan-urna",
                    Published = true,
                    PostedDate = new DateTime(2020, 9, 17, 1, 5, 0),
                    ModifiedDate = null,
                    ViewCount = 567,
                    Author = authors[5],
                    Category = categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[15]
                    }
                },

                new()
                {
                    Title = "Aenean elementum, nisi non vehicula tincidunt",
                    ShortDescription = "Etiam id tincidunt erat. Pellentesque sollicitudin, eros ac ultricies pulvinar, neque neque bibendum quam, vel porta sapien neque efficitur sem. Etiam volutpat, purus vel condimentum aliquam",
                    Description = "ed tincidunt, nisl at fermentum euismod, nunc lectus maximus ligula, convallis varius tortor quam at odio. Aenean odio justo, sodales non consequat at, finibus non justo.\r\n\r\nDonec molestie, massa eget eleifend porta, velit tortor feugiat orci, nec pharetra augue augue eget sem. Vivamus quam mi, euismod a volutpat id, aliquam sed risus. Nunc at iaculis odio, at consequat est. Suspendisse dolor augue, suscipit eget mauris et, blandit consequat ex. Suspendisse nec turpis egestas, tempor leo ac, laoreet orci. In gravida imperdiet magna ac scelerisque. Mauris ac erat arcu. Mauris non porttitor erat, aliquet pulvinar urna. Praesent quis varius nunc, eget congue nibh. Donec nec lobortis velit, ut vestibulum arcu. Cras leo purus, tristique in mollis eget, molestie at lectus. Mauris et ante quam. Fusce aliquet eget magna nec congue.\r\n\r\nSed porttitor sem erat, ut fringilla erat congue non. Aenean cursus, libero sit amet rutrum commodo, turpis ante elementum nibh, quis laoreet felis urna sollicitudin dolor. Phasellus vestibulum rhoncus ultrices. Sed non elementum sapien. Mauris laoreet velit mauris, id dictum nulla maximus ac. In mi eros, fringilla vitae maximus vitae, porta nec justo. Donec elit ligula, vestibulum quis semper sed, commodo in mauris. Fusce fermentum turpis augue, eget convallis enim pellentesque sit amet. Donec tristique, odio in rhoncus blandit, nisi augue luctus tortor, molestie venenatis urna nisi non ligula. Phasellus turpis lectus, vestibulum et faucibus quis, vehicula et magna. Sed vulputate leo nulla, in porttitor nunc maximus convallis. Fusce ultricies mattis tortor. Nullam non arcu vitae mi vestibulum hendrerit at et nibh. Nulla varius dui in mi gravida, ut luctus nunc cursus. Morbi pellentesque lobortis magna, quis aliquam lacus pellentesque at.",
                    Meta = "Etiam id tincidunt erat. Pellentesque sollicitudin, eros ac ultricies pulvinar, neque neque bibendum quam, vel porta sapien neque efficitur sem. Etiam volutpat, purus vel condimentum aliquam",
                    UrlSlug = "aenean-elementum-nisi-non-vehicula-tincidunt",
                    Published = true,
                    PostedDate = new DateTime(2021, 8, 22, 1, 15, 0),
                    ModifiedDate = null,
                    ViewCount = 1070,
                    Author = authors[5],
                    Category = categories[7],
                    Tags = new List<Tag>()
                    {
                        tags[15]
                    }
                },

                //================================================20

                new()
                {
                    Title = "In dapibus dui lorem, in luctus lacus consectetur et.",
                    ShortDescription = "n hac habitasse platea dictumst. Morbi at nisl tempor, varius orci bibendum, commodo leo. In odio velit, laoreet ut diam vulputate",
                    Description = "ulputate eleifend ante. Maecenas venenatis enim eu mi hendrerit, quis tincidunt lacus tempor. Donec aliquet eget massa id laoreet. Nullam a nunc lacus. Quisque vulputate lectus nec enim semper commodo. Vivamus sed nulla ut diam gravida cursus. Pellentesque ex ligula, lobortis eget est quis, tincidunt dignissim augue.\r\n\r\nVestibulum in velit tortor. Sed rhoncus, quam ac dapibus efficitur, nisi erat ultrices lorem, ut congue dui sem sit amet nibh. Nullam a neque sed magna lacinia auctor. Suspendisse potenti. Vestibulum vitae felis maximus, ultricies elit non, euismod mi. Nullam rutrum diam vel risus pulvinar porta. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nulla ac tempor erat, quis viverra purus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Nulla tempor placerat lacus, eget tincidunt felis commodo ut. Nulla facilisi. Fusce blandit iaculis libero eget scelerisque. Nulla elit augue, accumsan et sodales quis, ullamcorper in sapien. Praesent nulla lorem, vestibulum convallis metus ac, finibus imperdiet lacus. Pellentesque aliquam massa et venenatis viverra. Curabitur id diam ac dolor dapibus fringilla ac non turpis.",
                    Meta = "n hac habitasse platea dictumst. Morbi at nisl tempor, varius orci bibendum, commodo leo. In odio velit, laoreet ut diam vulputate",
                    UrlSlug = "in-dapibus-dui-lorem-in-luctus-lacus-consectetur-et",
                    Published = true,
                    PostedDate = new DateTime(2020, 9, 30, 1, 7, 0),
                    ModifiedDate = null,
                    ViewCount = 500,
                    Author = authors[0],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[12]
                    }
                },

                new()
                {
                    Title = "Aenean eu faucibus nulla.",
                    ShortDescription = "Suspendisse sed libero nec tortor viverra aliquam nec iaculis lectus. Donec mauris est, molestie tristique lectus vel, posuere pretium ipsum",
                    Description = "Mauris vitae ex augue. Duis mollis felis accumsan malesuada tempus. Duis tincidunt mi at pulvinar ultrices. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Morbi lacinia tortor sollicitudin, tempus purus ac, imperdiet augue. Integer laoreet blandit efficitur. Donec elit ante, molestie sit amet mauris in, consectetur euismod sapien. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec nec turpis nec magna lobortis congue sit amet sed odio.\r\n\r\nFusce congue augue mollis enim rhoncus, volutpat mattis nisi laoreet. Duis id ligula lorem. In hac habitasse platea dictumst. Duis a neque egestas, rhoncus felis a, tristique nisl. Cras et magna tempor, tristique neque ultricies, fermentum ante. Donec posuere dictum tincidunt. Pellentesque id scelerisque ligula. Duis mollis mollis viverra. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.\r\n\r\nPhasellus at tincidunt tellus. Sed ac nibh vel tortor mattis eleifend. Praesent vel erat sollicitudin, varius mi non, fermentum urna. Quisque posuere velit in fringilla molestie. Sed eu congue risus, ut euismod tortor. Ut id luctus nibh. Cras sodales luctus nunc, nec lacinia massa porta nec. Ut sit amet vestibulum ex. Sed cursus lectus ullamcorper varius ornare. Ut at neque massa. Aliquam tincidunt vel magna eget pharetra. In pulvinar, massa vel pharetra hendrerit, sapien mauris porta sapien, quis pulvinar magna lacus ut mi. Integer facilisis venenatis eros. Donec eros dolor, blandit et nunc vitae, fringilla lacinia ipsum. Praesent at sem a elit venenatis tincidunt. Nunc massa augue, lacinia quis molestie a, sagittis eu tellus.",
                    Meta = "Suspendisse sed libero nec tortor viverra aliquam nec iaculis lectus. Donec mauris est, molestie tristique lectus vel, posuere pretium ipsum",
                    UrlSlug = "aenean-eu-faucibus-nulla",
                    Published = true,
                    PostedDate = new DateTime(2021, 12, 30, 10, 45, 0),
                    ModifiedDate = null,
                    ViewCount = 100,
                    Author = authors[0],
                    Category = categories[1],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },

                new()
                {
                    Title = "Curabitur ut eros rutrum felis pharetra convallis id quis tellus",
                    ShortDescription = "Donec et mi dictum, aliquam turpis vitae, fringilla nibh. Sed tincidunt maximus ligula, eu fringilla mauris lobortis in. Sed sit amet nunc rutrum, auctor velit sit amet, aliquet felis.",
                    Description = "Donec et mi dictum, aliquam turpis vitae, fringilla nibh. Sed tincidunt maximus ligula, eu fringilla mauris lobortis in. Sed sit amet nunc rutrum, auctor velit sit amet, aliquet felis.",
                    Meta = "Donec et mi dictum, aliquam turpis vitae, fringilla nibh. Sed tincidunt maximus ligula, eu fringilla mauris lobortis in. Sed sit amet nunc rutrum, auctor velit sit amet, aliquet felis.",
                    UrlSlug = "curabitur-ut-eros-rutrum-felis-pharetra-convallis-id-quis-tellus",
                    Published = true,
                    PostedDate = new DateTime(2022, 9, 10, 7, 22, 0),
                    ModifiedDate = null,
                    ViewCount = 800,
                    Author = authors[1],
                    Category = categories[8],
                    Tags = new List<Tag>()
                    {
                        tags[16]
                    }
                },

                new()
                {
                    Title = "Phasellus fermentum, dui eu varius congue",
                    ShortDescription = "Maecenas blandit odio condimentum pretium tincidunt. Pellentesque tristique nisi eget sapien sagittis, in posuere neque lacinia. Etiam luctus mauris non cursus mollis.",
                    Description = "Maecenas blandit odio condimentum pretium tincidunt. Pellentesque tristique nisi eget sapien sagittis, in posuere neque lacinia. Etiam luctus mauris non cursus mollis.",
                    Meta = "Maecenas blandit odio condimentum pretium tincidunt. Pellentesque tristique nisi eget sapien sagittis, in posuere neque lacinia. Etiam luctus mauris non cursus mollis.",
                    UrlSlug = "phasellus-fermentum-dui-eu-varius-congue",
                    Published = true,
                    PostedDate = new DateTime(2021, 1, 30, 7, 45, 0),
                    ModifiedDate = null,
                    ViewCount = 770,
                    Author = authors[1],
                    Category = categories[7],
                    Tags = new List<Tag>()
                    {
                        tags[13]
                    }
                },

                new()
                {
                    Title = "Nunc nec est quis est vulputate sollicitudin",
                    ShortDescription = "Donec dictum vitae augue sed semper. Suspendisse et hendrerit elit, nec auctor justo.",
                    Description = "Vivamus tristique, neque sit amet volutpat ultricies, felis libero ornare ligula, id faucibus metus erat ut metus. Nunc lacus lacus, ullamcorper sollicitudin aliquam id, lacinia at massa. Nulla ut tellus id nisl placerat auctor. Vivamus nunc nibh, tempus vel odio semper, lacinia dictum enim. Nulla pretium sed turpis semper laoreet. Curabitur vestibulum turpis turpis, at vehicula quam volutpat sit amet. Curabitur fermentum posuere dui, nec elementum magna condimentum euismod. Quisque tincidunt ipsum non urna pulvinar viverra. Nulla sodales dolor id scelerisque aliquam. Sed vitae ornare leo. Suspendisse porttitor cursus arcu vitae elementum. Mauris nec augue et urna molestie faucibus. Suspendisse placerat consectetur nunc imperdiet bibendum.\r\n\r\nSed quis rhoncus quam. Aenean a erat arcu. Suspendisse in malesuada leo. Fusce id ultricies orci. Maecenas volutpat dui vitae ipsum fermentum consequat. Nunc eu tortor non metus dapibus euismod. Proin varius erat sit amet velit ullamcorper, in bibendum augue commodo. Nam nec suscipit eros. Nunc eget commodo libero. Etiam et ex non purus porta porta. Mauris semper, quam sed blandit congue, nibh lorem consectetur lectus, id ornare diam libero vel ipsum. Maecenas a enim volutpat, egestas libero eu, congue erat. Aliquam in aliquam enim. In lacinia neque et faucibus blandit.",
                    Meta = "Donec dictum vitae augue sed semper. Suspendisse et hendrerit elit, nec auctor justo.",
                    UrlSlug = "nunc-nec-est-quis-est-vulputate-sollicitudin",
                    Published = true,
                    PostedDate = new DateTime(2020, 7, 3, 3, 33, 0),
                    ModifiedDate = null,
                    ViewCount = 1500,
                    Author = authors[2],
                    Category = categories[9],
                    Tags = new List<Tag>()
                    {
                        tags[4]
                    }
                },

                //================================================25
                new()
                {
                    Title = "Nulla hendrerit diam nec faucibus sodales",
                    ShortDescription = "Nam viverra bibendum lorem. Vivamus malesuada molestie mi. Nulla augue mi, consequat blandit gravida sed, sollicitudin laoreet nunc.",
                    Description = "Ut nulla eros, consectetur vel finibus in, scelerisque et turpis. Vestibulum faucibus mattis libero eu molestie. Suspendisse aliquet eu ligula quis malesuada. Proin bibendum vehicula elit ac mollis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam dapibus malesuada ultrices. Quisque purus tellus, laoreet et viverra non, ornare quis sem. Nunc tristique risus eget nisl cursus, sed aliquam quam aliquet.\r\n\r\nPellentesque interdum odio est, eget tempor lectus molestie sit amet. Proin sodales maximus lectus, et hendrerit metus consequat sit amet. Donec tempus justo sed est sollicitudin efficitur. Curabitur vitae molestie est. Morbi egestas dolor eu quam commodo, vel sodales leo elementum. Phasellus risus leo, eleifend et faucibus vitae, sagittis quis libero. Mauris at consectetur neque. Suspendisse tincidunt mi urna, in eleifend sapien imperdiet eu. Maecenas fermentum lobortis sem auctor molestie. Quisque pharetra cursus neque. Mauris non magna sit amet enim auctor tincidunt at vel diam. Maecenas vestibulum tempor mauris non lacinia. Integer non dolor fermentum sem volutpat sollicitudin. Fusce dolor est, viverra et nisl non, aliquam rutrum lorem.",
                    Meta = "Nam viverra bibendum lorem. Vivamus malesuada molestie mi. Nulla augue mi, consequat blandit gravida sed, sollicitudin laoreet nunc.",
                    UrlSlug = "nulla-hendrerit-diam-nec-faucibus-sodales",
                    Published = true,
                    PostedDate = new DateTime(2022, 11, 30, 1, 11, 0),
                    ModifiedDate = null,
                    ViewCount = 896,
                    Author = authors[3],
                    Category = categories[9],
                    Tags = new List<Tag>()
                    {
                        tags[14]
                    }
                },

                new()
                {
                    Title = "Fusce id vulputate lacus. Nulla posuere quam a tempus sodales",
                    ShortDescription = "Fusce id vulputate lacus. Nulla posuere quam a tempus sodales",
                    Description = "Sed non dictum leo. Maecenas ut dui in sapien hendrerit ornare. Aenean at nibh odio. Ut non nibh eu risus finibus tincidunt. Aliquam erat volutpat. Duis auctor pretium ipsum vitae egestas. Cras dictum risus in orci vulputate ultrices. Donec fringilla massa nec diam sollicitudin egestas. Nullam interdum eros a tincidunt tempor. Praesent a elit a massa dignissim consequat vel vitae tellus. Aliquam sapien nisi, lacinia ut dolor quis, tristique bibendum eros. Aenean semper, risus et malesuada congue, mauris mi fermentum orci, eget sagittis tellus ipsum vel eros. Quisque ullamcorper, nibh et eleifend lobortis, lacus tellus volutpat justo, nec accumsan metus enim quis massa.\r\n\r\nNunc blandit fringilla eros, vel facilisis massa varius nec. Vestibulum nunc ex, rutrum non ligula in, cursus pretium elit. Pellentesque egestas elit lorem, eu ullamcorper odio ullamcorper eu. Nunc semper semper ex, at eleifend mi pretium quis. Morbi risus nunc, aliquam ut aliquam vel, molestie nec nibh. In nec volutpat nulla. Curabitur pellentesque felis non placerat blandit. Ut rutrum tortor non orci imperdiet, vitae mattis libero porta. Mauris finibus metus nibh, eget sagittis risus pulvinar nec.\r\n\r\nFusce imperdiet nulla ipsum, quis venenatis enim iaculis semper. Sed vel mi est. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed nec accumsan enim. Curabitur non ultricies eros. Aliquam quis laoreet dui. Donec vitae felis volutpat sem pulvinar aliquet quis ac nisi. Sed vitae metus in eros rutrum sollicitudin et at leo. Vestibulum malesuada non nisi at malesuada. Proin at tincidunt lorem, vitae aliquet est. Mauris sit amet mauris ac nibh rhoncus vulputate. Curabitur ultricies, arcu sit amet suscipit imperdiet, sem diam eleifend mauris, et fermentum nisi magna eu ligula.",
                    Meta = "Fusce id vulputate lacus. Nulla posuere quam a tempus sodales",
                    UrlSlug = "fusce-id-vulputate-lacus-nulla-posuere-quam-a-tempus-sodales",
                    Published = true,
                    PostedDate = new DateTime(2020, 9, 11, 6, 23, 0),
                    ModifiedDate = null,
                    ViewCount = 189,
                    Author = authors[4],
                    Category = categories[1],
                    Tags = new List<Tag>()
                    {
                        tags[18]
                    }
                },

                new()
                {
                    Title = "Pellentesque sit amet tristique ligula",
                    ShortDescription = "Duis id velit mi. Donec viverra tortor ut ornare sagittis. Etiam mollis mi felis. Nunc sit amet metus in ante vehicula pharetra sed quis odio",
                    Description = "In quis lacinia est, sit amet ornare justo. Sed sit amet enim aliquet, maximus nibh non, euismod lacus. Duis aliquam purus vitae augue consequat, quis sagittis orci auctor.\r\n\r\nMauris sit amet leo nec lacus porttitor rutrum sit amet at felis. Nulla nec sollicitudin sem. Mauris non augue non erat sodales tempor. Aliquam condimentum convallis lectus, eget ultrices neque aliquet in. Aenean sem lorem, vehicula id sodales a, bibendum eu neque. Mauris non massa at orci molestie porta ut ac felis. Praesent sed nibh in nunc tristique interdum in eu est. Nulla malesuada, augue ac volutpat laoreet, purus dui suscipit risus, ac ultrices felis ante sit amet lacus.\r\n\r\nQuisque nibh nisl, efficitur id pharetra ac, condimentum in tortor. Nulla quis egestas metus, vitae luctus elit. Suspendisse in ullamcorper dui. Proin mattis, eros sed condimentum consectetur, ligula nulla lobortis magna, quis iaculis purus mi in dui. Cras eu venenatis dolor. Integer sollicitudin aliquam diam, volutpat dictum orci pharetra et. Phasellus pulvinar, nisi at suscipit venenatis, lacus sapien porta augue, vel volutpat ligula lorem interdum lacus. Donec ut massa tincidunt, tincidunt nunc ac, semper dui. Sed sit amet lorem magna. Maecenas tempor nulla id nibh rhoncus, id pretium odio egestas. Sed a molestie nisl, pretium ultrices enim. Etiam ornare erat ut sollicitudin malesuada.",
                    Meta = "Duis id velit mi. Donec viverra tortor ut ornare sagittis. Etiam mollis mi felis. Nunc sit amet metus in ante vehicula pharetra sed quis odio",
                    UrlSlug = "pellentesque-sit-amet-tristique-ligula",
                    Published = true,
                    PostedDate = new DateTime(2022, 9, 10, 1, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 890,
                    Author = authors[5],
                    Category = categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[11]
                    }
                },

                new()
                {
                    Title = "Ut eu lacus varius, tristique urna sed, elementum enim",
                    ShortDescription = "Aliquam erat volutpat. Aenean eu maximus nisl. Phasellus vitae ornare eros, id facilisis mi.",
                    Description = "Aliquam erat volutpat. Aenean eu maximus nisl. Phasellus vitae ornare eros, id facilisis mi.",
                    Meta = "Aliquam erat volutpat. Aenean eu maximus nisl. Phasellus vitae ornare eros, id facilisis mi.",
                    UrlSlug = "ut-eu-lacus-varius-tristique-urna-sed-elementum-enim",
                    Published = true,
                    PostedDate = new DateTime(2022, 1, 3, 5, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 1890,
                    Author = authors[4],
                    Category = categories[8],
                    Tags = new List<Tag>()
                    {
                        tags[12]
                    }
                },

                new()
                {
                    Title = "Morbi id facilisis sapien. Sed quis iaculis justo",
                    ShortDescription = "Aenean condimentum lectus et nisi pharetra, eu laoreet arcu varius. Fusce eros massa, tincidunt ut auctor in, auctor a felis.",
                    Description = "Curabitur in purus quis ipsum egestas ullamcorper. Phasellus nisl dolor, pretium id cursus quis, volutpat at lacus. Etiam scelerisque orci lectus, vel mattis orci varius ut. Nunc vel diam fringilla, bibendum dolor placerat, tristique velit. Ut egestas venenatis mi, vitae consequat risus congue vitae. Nullam suscipit mollis cursus. Maecenas vitae rutrum est. Phasellus tellus ante, bibendum et interdum vitae, suscipit et lorem. Nulla suscipit augue et leo elementum efficitur. Pellentesque nec enim euismod, bibendum odio gravida, malesuada massa.\r\n\r\nAenean diam lacus, pretium a elit ut, iaculis hendrerit mauris. Quisque ac convallis enim. Donec pulvinar, lacus eget tempor vulputate, arcu urna laoreet tellus, vitae lacinia purus orci sit amet quam. Proin pellentesque turpis ornare fringilla accumsan. Mauris scelerisque tortor et arcu feugiat lobortis. Integer lacinia venenatis erat, sit amet rutrum ante ultrices in. Sed porttitor, nunc feugiat iaculis auctor, velit risus auctor nulla, id porta libero risus id nisl. Ut egestas convallis mi vitae lacinia. Fusce facilisis a nibh vel aliquam. Sed varius purus sit amet tortor euismod vehicula. Vestibulum accumsan, dui at ultrices condimentum, lacus nunc commodo purus, at hendrerit sem lorem id ipsum.\r\n\r\nAliquam eget mauris venenatis orci scelerisque bibendum eleifend sit amet lorem. Fusce at massa porta, malesuada nisi ac, convallis neque. Aliquam non porta diam. Vestibulum non elit ac tortor interdum malesuada. Vestibulum velit dolor, euismod ac semper id, tristique vel lacus. Aenean sed ipsum eros. Mauris consectetur laoreet est vitae aliquam. Curabitur euismod purus sit amet felis suscipit dapibus. Quisque euismod leo nulla, ut tincidunt orci consectetur id. Donec scelerisque justo lacus, vel ornare velit gravida quis.\r\n\r\nNam aliquam imperdiet urna a vestibulum. Phasellus mattis, justo eu consectetur fermentum, elit magna molestie lectus, at molestie augue urna ut justo. In aliquet nisl a tellus tincidunt, rutrum imperdiet nunc molestie. Etiam sed finibus ipsum. Quisque elementum varius orci, quis aliquet ante fringilla nec. Etiam ac suscipit erat, tincidunt tempor metus. Mauris gravida sollicitudin massa et porta. Phasellus ac bibendum lectus. Sed vitae rhoncus ipsum. Maecenas quis ante ac urna gravida rutrum. Cras in porttitor lorem. Pellentesque elit metus, fermentum quis eros in, convallis porta sem. Sed interdum efficitur mattis. Pellentesque mattis lorem eget quam facilisis, id vehicula nulla accumsan.",
                    Meta = "Aenean condimentum lectus et nisi pharetra, eu laoreet arcu varius. Fusce eros massa, tincidunt ut auctor in, auctor a felis.",
                    UrlSlug = "morbi-id-facilisis-sapien-sed-quis-iaculis-justo",
                    Published = true,
                    PostedDate = new DateTime(2023, 1, 3, 10, 55, 0),
                    ModifiedDate = null,
                    ViewCount = 1059,
                    Author = authors[4],
                    Category = categories[8],
                    Tags = new List<Tag>()
                    {
                        tags[14]
                    }
                }
                //================================================30
            };

            _dbContext.Posts.AddRange(posts);
            _dbContext.SaveChanges();

            return posts;
        }
    }
}
