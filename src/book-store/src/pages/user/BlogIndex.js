import React, { useEffect, useState } from "react";
import AnimationRevealPage from "helpers/AnimationRevealPage.js";
import { Container, ContentWithNoPadding } from "components/user/misc/Layouts";
import tw from "twin.macro";
import styled from "styled-components";
import { css } from "styled-components/macro";
import { SectionHeading } from "components/user/misc/Headings";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { PrimaryButton } from "components/user/misc/Buttons";
import { Link } from "react-router-dom";
import PostDefault from "images/post-default.png";
import { getPosts } from "../../services/PostRepository";
import { formatDateTme } from "../../components/utils/Utils";
import { getCategories } from "../../services/CategoryRepository";
import { faTag } from "@fortawesome/free-solid-svg-icons";



const HeadingRow = tw.div`flex`;
// const Heading = tw(SectionHeading)`text-gray-900`;
const Posts = tw.div`mt-0 sm:-mr-8 flex flex-wrap`;
const PostContainer = styled.div`
  ${tw`mt-10 w-full sm:w-1/2 lg:w-1/3 sm:pr-8`}
  ${props =>
    props.featured &&
    css`
      ${tw`w-full!`}
      ${Post} {
        ${tw`sm:flex-row! h-full sm:pr-4`}
      }
      ${Image} {
        ${tw`sm:h-96 sm:min-h-full sm:w-1/2 lg:w-2/3 sm:rounded-t-none sm:rounded-l-lg`}
      }
      ${Info} {
        ${tw`sm:-mr-4 sm:pl-8 sm:flex-1 sm:rounded-none sm:rounded-r-lg sm:border-t-2 sm:border-l-0 border-gray-200`}
      }
      ${Description} {
        ${tw`text-sm mt-3 leading-loose text-gray-600 font-medium`}
      }
    `}
`;
const Post = tw.div`cursor-pointer flex flex-col bg-gray-100 rounded-lg shadow-lg`;
const Image = styled.div`
  ${props => css`background-image: url("${props.imageSrc}");`}
  ${tw`h-64 w-full bg-cover bg-center rounded-t-lg`}
`;
const Info = tw.div`p-8 border-2 border-t-0 rounded-lg rounded-t-none border-gray-200`;
const Category = tw.div`uppercase text-primary-500 text-xs font-bold tracking-widest leading-loose after:content after:block after:border-b-2 after:border-primary-500 after:w-8`;
const CreationDate = tw.div`mt-4 uppercase text-gray-600 font-semibold text-xs`;
const Title = tw.div`mt-1 font-black text-2xl text-gray-900 group-hover:text-primary-500 transition duration-300`;
const Description = tw.div``;

const ButtonContainer = tw.div`flex justify-center`;
const LoadMoreButton = tw(PrimaryButton)`mt-16 mx-auto`;

const TagContainer = tw.div`my-3 flex flex-wrap`;
const TagItem = tw.p`mr-3 my-2 py-2 px-3 bg-teal-400 rounded-lg font-semibold text-xs text-white`;
const Heading = tw(SectionHeading)`text-gray-900 mb-0 mt-3 text-lg text-left mr-3`;

export default ({
  headingText = "Bài viết",
  // posts = [
  //   {
  //     imageSrc:
  //       "https://images.unsplash.com/photo-1499678329028-101435549a4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1024&q=80",
  //     category: "Travel Tips",
  //     date: "April 21, 2020",
  //     title: "Safely Travel in Foreign Countries",
  //     description:
  //       "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.  Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
  //     url: "https://timerse.com",
  //     featured: true
  //   },
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost(),
  //   getPlaceholderPost()
  // ]
}) => {
  const [visible, setVisible] = useState(7);
  const onLoadMoreClick = () => {
    setVisible(v => v + 7);
  };

  let featured = false;

  const [postsList, setPostsList] = useState([]);
  const [metadata, setMetadata] = useState([]);
  const [categoriesList, setCategoriesList] = useState([]);


  useEffect(() => {
    document.title = 'Trang chủ';

    getPosts().then(data => {
      if (data) {
        setPostsList(data.items);
        setMetadata(data.metadata);
      }
      else
        setPostsList([]);
      console.log(data.items)
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

  }, []);

  return (
    <AnimationRevealPage>
      <Container>
        <ContentWithNoPadding>

          <TagContainer>
            <Heading>
              Chủ đề:
            </Heading>
            {categoriesList.map((category, index) => (
              <a href={`blog/${category.urlSlug}`}>
                <TagItem key={index}>
                  <FontAwesomeIcon icon={faTag} className="pr-2" />
                  {category.name}
                </TagItem>
              </a>
            ))}
          </TagContainer>
          <Posts>
            {postsList.slice(0, visible).map((post, index) => (
              <>
                {index % 7 === 0 ? featured = true : featured = false}
                <PostContainer key={index} featured={featured}>
                  <Post className="group" as="a" href={`/blog-detail/${post.urlSlug}`}>
                    <Image imageSrc={PostDefault} />
                    <Info>
                      <Category>{post.author.fullName}</Category>
                      <CreationDate>{formatDateTme(post.postedDate)}</CreationDate>
                      <a href={`/blog-detail/${post.urlSlug}`}>
                        <Title>{post.title}</Title>
                      </a>
                      {featured === true ?
                        <Description css={tw``}>{post.shortDescription}</Description>
                        :
                        <Description css={tw`line-clamp-3 mt-2`}>{post.shortDescription}</Description>
                      }
                    </Info>
                  </Post>
                </PostContainer>
              </>
            ))}
          </Posts>
          {visible < postsList.length && (
            <ButtonContainer>
              <LoadMoreButton onClick={onLoadMoreClick}>Xem thêm</LoadMoreButton>
            </ButtonContainer>
          )}
        </ContentWithNoPadding>
      </Container>
    </AnimationRevealPage>
  );
};
