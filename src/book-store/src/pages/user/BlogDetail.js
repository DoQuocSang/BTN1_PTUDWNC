import React from "react";
import AnimationRevealPage from "helpers/AnimationRevealPage.js";
import { Container, ContentWithPaddingXl } from "components/user/misc/Layouts";
import tw from "twin.macro";
import styled from "styled-components";
import { SectionHeading } from "components/user/misc/Headings";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCalendarCheck, faTag, faUserPen } from "@fortawesome/free-solid-svg-icons";

const HeadingRow = tw.div`flex`;
const BlogImage = tw.img`w-full h-auto rounded-lg p-4`;
const Heading = tw(SectionHeading)`text-gray-900 mb-0 text-4xl`;
const PaddingContainer = tw.div`mx-32 my-10`;
const TagContainer = tw.div`my-3 flex`;
const TagItem = tw.p`mr-3 py-2 px-4 bg-teal-400 rounded-lg font-semibold text-xs text-white`;

const InfoContainer = tw.div`my-3 text-right`;
const InfoItem = tw.p`py-1 font-semibold text-base text-gray-500`;

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
export default ({ headingText = "Privacy Policy" }) => {
  return (
    <AnimationRevealPage>
      <Container>
        <ContentWithPaddingXl>
        <BlogImage src="https://aeonmall-long-bien.com.vn/wp-content/uploads/2022/01/269302567_4487714621350494_4627200227809060552_n.jpg" />

          <HeadingRow>
            <Heading>{headingText}</Heading>
          </HeadingRow>

            <TagContainer>
              <TagItem>
              <FontAwesomeIcon icon={faTag} className="pr-2" />
                Bán chạy
              </TagItem>
              <TagItem>
                <FontAwesomeIcon icon={faTag} className="pr-2" />
                Bán chạy
              </TagItem>
            </TagContainer>

          <Text>
          
            <h3>Usage Data</h3>
            <p>Usage Data is collected automatically when using the Service.</p>
            <p>
              Usage Data may include information such as Your Device's Internet Protocol address (e.g. IP address),
              browser type, browser version, the pages of our Service that You visit, the time and date of Your visit,
              the time spent on those pages, unique device identifiers and other diagnostic data.
            </p>
            <p>
              When You access the Service by or through a mobile device, We may collect certain information
              automatically, including, but not limited to, the type of mobile device You use, Your mobile device unique
              ID, the IP address of Your mobile device, Your mobile operating system, the type of mobile Internet
              browser You use, unique device identifiers and other diagnostic data.
            </p>
            <p>
              We may also collect information that Your browser sends whenever You visit our Service or when You access
              the Service by or through a mobile device.
            </p>

            <h3>Tracking Technologies and Cookies</h3>
            <p>
              We use Cookies and similar tracking technologies to track the activity on Our Service and store certain
              information. Tracking technologies used are beacons, tags, and scripts to collect and track information
              and to improve and analyze Our Service.
            </p>
            <p>
              You can instruct Your browser to refuse all Cookies or to indicate when a Cookie is being sent. However,
              if You do not accept Cookies, You may not be able to use some parts of our Service.
            </p>
            <p>
              Cookies can be "Persistent" or "Session" Cookies. Persistent Cookies remain on your personal computer or
              mobile device when You go offline, while Session Cookies are deleted as soon as You close your web
              browser. Learn more about cookies: <a href="https://www.termsfeed.com/blog/cookies/">All About Cookies</a>
              .
            </p>
            <p>We use both session and persistent Cookies for the purposes set out below:</p>
            <ul>
              <li>
                <p>
                  <strong>Necessary / Essential Cookies</strong>
                </p>
                <p>Type: Session Cookies</p>
                <p>Administered by: Us</p>
                <p>
                  Purpose: These Cookies are essential to provide You with services available through the Website and to
                  enable You to use some of its features. They help to authenticate users and prevent fraudulent use of
                  user accounts. Without these Cookies, the services that You have asked for cannot be provided, and We
                  only use these Cookies to provide You with those services.
                </p>
              </li>
              <li>
                <p>
                  <strong>Cookies Policy / Notice Acceptance Cookies</strong>
                </p>
                <p>Type: Persistent Cookies</p>
                <p>Administered by: Us</p>
                <p>Purpose: These Cookies identify if users have accepted the use of cookies on the Website.</p>
              </li>
              <li>
                <p>
                  <strong>Functionality Cookies</strong>
                </p>
                <p>Type: Persistent Cookies</p>
                <p>Administered by: Us</p>
                <p>
                  Purpose: These Cookies allow us to remember choices You make when You use the Website, such as
                  remembering your login details or language preference. The purpose of these Cookies is to provide You
                  with a more personal experience and to avoid You having to re-enter your preferences every time You
                  use the Website.
                </p>
              </li>
            </ul>
            <p>
              For more information about the cookies we use and your choices regarding cookies, please visit our Cookies
              Policy.
            </p>

            <h2>Transfer of Your Personal Data</h2>
            <p>
              Your information, including Personal Data, is processed at the Company's operating offices and in any
              other places where the parties involved in the processing are located. It means that this information may
              be transferred to — and maintained on — computers located outside of Your state, province, country or
              other governmental jurisdiction where the data protection laws may differ than those from Your
              jurisdiction.
            </p>
            <p>
              Your consent to this Privacy Policy followed by Your submission of such information represents Your
              agreement to that transfer.
            </p>
            <p>
              The Company will take all steps reasonably necessary to ensure that Your data is treated securely and in
              accordance with this Privacy Policy and no transfer of Your Personal Data will take place to an
              organization or a country unless there are adequate controls in place including the security of Your data
              and other personal information.
            </p>

            <h2>Disclosure of Your Personal Data</h2>
            <h3>Business Transactions</h3>
            <p>
              If the Company is involved in a merger, acquisition or asset sale, Your Personal Data may be transferred.
              We will provide notice before Your Personal Data is transferred and becomes subject to a different Privacy
              Policy.
            </p>
            <h3>Law enforcement</h3>
            <p>
              Under certain circumstances, the Company may be required to disclose Your Personal Data if required to do
              so by law or in response to valid requests by public authorities (e.g. a court or a government agency).
            </p>
            <h3>Other legal requirements</h3>
            <p>
              The Company may disclose Your Personal Data in the good faith belief that such action is necessary to:
            </p>
            <ul>
              <li>Comply with a legal obligation</li>
              <li>Protect and defend the rights or property of the Company</li>
              <li>Prevent or investigate possible wrongdoing in connection with the Service</li>
              <li>Protect the personal safety of Users of the Service or the public</li>
              <li>Protect against legal liability</li>
            </ul>

            <h2>Security of Your Personal Data</h2>
            <p>
              The security of Your Personal Data is important to Us, but remember that no method of transmission over
              the Internet, or method of electronic storage is 100% secure. While We strive to use commercially
              acceptable means to protect Your Personal Data, We cannot guarantee its absolute security.
            </p>

            <h1>Children's Privacy</h1>
            <p>
              Our Service does not address anyone under the age of 13. We do not knowingly collect personally
              identifiable information from anyone under the age of 13. If You are a parent or guardian and You are
              aware that Your child has provided Us with Personal Data, please contact Us. If We become aware that We
              have collected Personal Data from anyone under the age of 13 without verification of parental consent, We
              take steps to remove that information from Our servers.
            </p>
            <p>
              If We need to rely on consent as a legal basis for processing Your information and Your country requires
              consent from a parent, We may require Your parent's consent before We collect and use that information.
            </p>

            <h1>Links to Other Websites</h1>
            <p>
              Our Service may contain links to other websites that are not operated by Us. If You click on a third party
              link, You will be directed to that third party's site. We strongly advise You to review the Privacy Policy
              of every site You visit.
            </p>
            <p>
              We have no control over and assume no responsibility for the content, privacy policies or practices of any
              third party sites or services.
            </p>

            <h1>Changes to this Privacy Policy</h1>
            <p>
              We may update our Privacy Policy from time to time. We will notify You of any changes by posting the new
              Privacy Policy on this page.
            </p>
            <p>
              We will let You know via email and/or a prominent notice on Our Service, prior to the change becoming
              effective and update the "Last updated" date at the top of this Privacy Policy.
            </p>
            <p>
              You are advised to review this Privacy Policy periodically for any changes. Changes to this Privacy Policy
              are effective when they are posted on this page.
            </p>
          </Text>
          <InfoContainer>
            <InfoItem>
              <FontAwesomeIcon icon={faUserPen} className="mr-2"/>
              Tác giả: Sang Đỗ
            </InfoItem>
            <InfoItem>
              <FontAwesomeIcon icon={faCalendarCheck} className="mr-2"/>
              Ngày đăng: 26/10/2023
            </InfoItem>
          </InfoContainer>
          </ContentWithPaddingXl>
      </Container>
    </AnimationRevealPage>
  );
};
