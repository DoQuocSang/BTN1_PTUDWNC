import React, { useEffect, useState } from "react";
import { useParams } from 'react-router-dom';
import AnimationRevealPage from "helpers/AnimationRevealPage.js";
import { Container, ContentWithPaddingXl } from "components/user/misc/Layouts";
import { motion } from "framer-motion";
import tw from "twin.macro";
import styled from "styled-components";
import { SectionHeading } from "components/user/misc/Headings";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCalendarCheck, faTag, faUserPen } from "@fortawesome/free-solid-svg-icons";
import { getPostBySlug } from "../../services/PostRepository";
import PostDefault from "images/post-default.png";
import PostDefaultFull from "images/post-default-full.png";
import { getRandomPosts } from "../../services/PostRepository";
import { faEye } from "@fortawesome/free-solid-svg-icons";
import { getCategories } from "../../services/CategoryRepository";
import { getTags } from "../../services/TagRepository";

const HeadingRow = tw.div`flex`;
const BlogImage = tw.img`w-full h-auto rounded-lg py-4`;
// const BlogImage = styled.div(props => [
//   `background-image: url("${props.imageSrc}"); `,
//   tw`rounded md:w-1/2 lg:w-5/12 xl:w-1/3 flex-shrink-0 h-80 md:h-144 bg-cover bg-center mx-4 sm:mx-8 md:mx-4 lg:mx-8`
// ]);
const Heading = tw(SectionHeading)`text-gray-900 mb-0 mt-3 text-3xl text-left`;
const HeadingSmall = tw(Heading)`text-lg mr-3 `;

const TagContainer = tw.div`my-3 flex flex-wrap`;
const TagItem = tw.p`mr-3 my-2 py-2 px-3 bg-teal-400 rounded-lg font-semibold text-xs text-white transition duration-300 hover:bg-teal-500`;

const InfoContainer = tw.div`my-3 text-right`;
const InfoItem = tw.p`py-1 text-base text-gray-500`;

const Text = styled.div`
  ${tw`text-lg  text-gray-800`}
  p {
    ${tw`mt-2 leading-loose`}
  }
  h1 {
    ${tw`text-3xl font-bold mt-10`}
  }
  h2 {
    ${tw`text-2xl font-bold mt-8`}
  }
  h3 {
    ${tw`text-xl font-bold mt-6`}
  }
  ul {
    ${tw`list-disc list-inside`}
    li {
      ${tw`ml-2 mb-3`}
      p {
        ${tw`mt-0 inline leading-normal`}
      }
    }
  }
`;

const Row = tw.div`flex flex-col lg:flex-row mx-20 max-w-screen-xl mx-auto`;

const PopularPostsContainer = tw.div`lg:w-2/3 mr-16`;
const PostsContainer = tw.div`mt-5 `;
const Post = tw(motion.a)`block sm:max-w-sm cursor-pointer mb-16 last:mb-0 sm:mb-0 sm:odd:mr-8 lg:mr-8 xl:mr-16`;
const Category = tw(motion.a)`block sm:max-w-sm cursor-pointer py-3 px-4 border border-gray-200 shadow-md rounded-lg mb-4 last:mb-2 hover:bg-primary-500 transition duration-300`;

const Image = styled(motion.div)(props => [
  `background-image: url("${props.$imageSrc}");`,
  tw`h-64 bg-cover bg-center rounded mt-2`
]);
const Title = tw.h5`mt-6 text-xl font-bold transition duration-300 group-hover:text-primary-500 line-clamp-1`;
const CategoryTitle = tw.h5`text-base font-semibold transition duration-300 group-hover:text-white line-clamp-1`;

const PostCategory = tw(motion.a)`cursor-pointer font-semibold text-base transition duration-300 hover:text-primary-500`;

const Description = styled.p(({ moreShort }) => [
  tw`mt-2 font-medium text-secondary-100 leading-loose text-sm line-clamp-2`,
  moreShort && tw`line-clamp-2`,
]);

const AuthorName = tw.h6`font-semibold text-lg`;

const RecentPostsContainer = styled.div`
  ${tw`mt-24 lg:mt-0 lg:w-1/3`}
  ${PostsContainer} {
    ${tw`flex flex-wrap lg:flex-col`}
  }
  ${Post} {
    ${tw`flex justify-between mb-10 max-w-none w-full sm:w-1/2 lg:w-auto sm:odd:pr-12 lg:odd:pr-0 mr-0`}
  }
  ${Title} {
    ${tw`text-base xl:text-lg mt-0 mr-4 lg:max-w-xs`}
  }
  ${AuthorName} {
    ${tw`mt-3 text-sm text-secondary-100 font-normal leading-none`}
  }
  ${Image} {
    ${tw`h-20 w-20 flex-shrink-0`}
  }
`;
const PostTextContainer = tw.div`mr-8`



export default () => {

  const { slug } = useParams();
  //console.log(slug);
  const [postsList, setPostsList] = useState([]);
  const [categoriesList, setCategoriesList] = useState([]);
  const [tagsList, setTagsList] = useState([]);
  const [randomPostList, setRandomPostList] = useState([]);
  const [metadata, setMetadata] = useState([]);

  useEffect(() => {
    document.title = 'Thông tin sản phẩm';

    getPostBySlug(slug).then(data => {
      if (data) {
        setPostsList(data.items);
        setMetadata(data.metadata);
      }
      else
        setPostsList([]);
      //console.log(data.items)
    })

    getRandomPosts(5).then(data => {
      if (data) {
        setRandomPostList(data.items);
        setMetadata(data.metadata);
      }
      else
        setRandomPostList([]);
      //console.log(data)
    })

    getCategories().then(data => {
      if (data) {
        setCategoriesList(data.items);
        setMetadata(data.metadata);
      }
      else
        setCategoriesList([]);
      //console.log(data)
    })

    getTags().then(data => {
      if (data) {
        setTagsList(data.items);
        setMetadata(data.metadata);
      }
      else
        setTagsList([]);
      console.log(data)
    })

  }, []);

  const postBackgroundSizeAnimation = {
    rest: {
      backgroundSize: "100%"
    },
    hover: {
      backgroundSize: "110%"
    }
  };

  return (
    <AnimationRevealPage>
      <Container>
        <Row>
          {postsList.map((post, index) => (
            <PopularPostsContainer key={index}>
              <PostCategory href={`/blog/${post.category.urlSlug}`}>{post.category.name}</PostCategory>
              <Heading>{post.title}</Heading>
              <InfoItem>
                <FontAwesomeIcon icon={faEye} className="mr-2" />
                {"Số lượt xem: "}{post.viewCount}
              </InfoItem>
              <PostsContainer>
                <TagContainer>
                  {post.tags.map((tag, index) => (
                    <a href={`/blog/${tag.urlSlug}`}>
                      <TagItem key={index}>
                        <FontAwesomeIcon icon={faTag} className="pr-2" />
                        {tag.name}
                      </TagItem>
                    </a>
                  ))}
                </TagContainer>

                <BlogImage src={PostDefaultFull} />

                <Text>
                  <p>
                    {post.description}
                  </p>
                </Text>
                <InfoContainer>
                  <InfoItem>
                    <FontAwesomeIcon icon={faUserPen} className="mr-2" />
                    Tác giả: Sang Đỗ
                  </InfoItem>
                  <InfoItem>
                    <FontAwesomeIcon icon={faCalendarCheck} className="mr-2" />
                    Ngày đăng: 26/10/2023
                  </InfoItem>
                </InfoContainer>

                <TagContainer>
                  <HeadingSmall>
                    Thẻ:
                  </HeadingSmall>
                  {tagsList.map((tag, index) => (
                    <a href={`/blog/${tag.urlSlug}`}>
                      <TagItem key={index}>
                        <FontAwesomeIcon icon={faTag} className="pr-2" />
                        {tag.name}
                      </TagItem>
                    </a>
                  ))}
                </TagContainer>
              </PostsContainer>
            </PopularPostsContainer>
          ))}

          <RecentPostsContainer>
            <Heading>Các bài viết</Heading>
            <PostsContainer>
              {randomPostList.map((post, index) => (
                <Post key={index} href={`/blog-detail/${post.urlSlug}`} className="group">
                  <PostTextContainer>
                    <Title>{post.title}</Title>
                    <Description moreShort>{post.shortDescription}</Description>
                  </PostTextContainer>
                  <Image $imageSrc={PostDefault} />
                </Post>
              ))}
            </PostsContainer>

            <Heading>Các chủ đề</Heading>
            <PostsContainer>
              {categoriesList.map((category, index) => (
                <Category key={index} href={`/blog/${category.urlSlug}`} className="group">
                  <PostTextContainer>
                    <CategoryTitle>{`${category.name} (${category.postCount})`}</CategoryTitle>
                  </PostTextContainer>
                </Category>
              ))}
            </PostsContainer>
          </RecentPostsContainer>
        </Row>
      </Container>
    </AnimationRevealPage>
  );
};
