import React from "react";
import footerLogo from "../../assets/product/logo.png";
import FooterImg from "../../assets/website/Footer BG.jpeg";
import {
  FaFacebook,
  FaInstagram,
  FaLinkedin,
  FaLocationArrow,
  FaMobileAlt,
} from "react-icons/fa";
import { Link } from "react-router-dom";

interface FooterLink {
  title: string;
  link: string;
}

const Img: React.CSSProperties = {
  backgroundImage: `url(${FooterImg})`,
  backgroundPosition: "center",
  backgroundRepeat: "no-repeat",
  backgroundSize: "cover",
  height: "100%",
  width: "100%",
};

const FooterImpLinks: FooterLink[] = [
  {
    title: "Home",
    link: "/",
  },
  {
    title: "About",
    link: "/about-us",
  },
  {
    title: "Contact",
    link: "/contact-us",
  },
  {
    title: "Blog",
    link: "/#",
  },
];
const FooterLinks: FooterLink[] = [
  {
    title: "Menu",
    link: "/products",
  },
  {
    title: "Deal",
    link: "/deals",
  },
  {
    title: "Categories",
    link: "/categories",
  },
  {
    title: "Orders",
    link: "/orders",
  },
];

const Footer: React.FC = () => {
  return (
    <div style={Img} className="text-white pt-5">
      <div className="container mt-20">
        <div data-aos="zoom-in" className="grid md:grid-cols-3 pb-44 pt-5">
          <div className="py-8 px-4">
            <h1 className="sm:text-3xl text-xl font-bold sm:text-left text-justify mb-3 flex items-center gap-3">
              <img src={footerLogo} alt="" className="max-w-[50px]" />
              BurgerToNight
            </h1>
            <p>
              Lorem ipsum dolor sit amet consectetur adipisicing elit. Cum in
              beatae ea recusandae blanditiis veritatis.
            </p>
          </div>

          <div className="grid grid-cols-2 sm:grid-cols-3 col-span-2 md:pl-10">
            <div>
              <div className="py-8 px-4">
                <h1 className="sm:text-xl text-xl font-bold sm:text-left text-justify mb-3">
                  Important Links
                </h1>
                <ul className="flex flex-col gap-3">
                  {FooterImpLinks.map((item) => (
                    <Link to={item.link} key={item.title}>
                      <li className="cursor-pointer hover:text-primary hover:translate-x-1 duration-300 text-gray-200">
                        <span>{item.title}</span>
                      </li>
                    </Link>
                  ))}
                </ul>
              </div>
            </div>
            <div>
              <div className="py-8 px-4">
                <h1 className="sm:text-xl text-xl font-bold sm:text-left text-justify mb-3">
                  Links
                </h1>
                <ul className="flex flex-col gap-3">
                  {FooterLinks.map((item) => (
                    <Link to={item.link} key={item.title}>
                      <li className="cursor-pointer hover:text-primary hover:translate-x-1 duration-300 text-gray-200">
                        <span>{item.title}</span>
                      </li>
                    </Link>
                  ))}
                </ul>
              </div>
            </div>

            <div>
              <div className="flex items-center gap-3 mt-6">
                <a href="https://www.instagram.com/usman.the.coder/">
                  <FaInstagram className="text-3xl" />
                </a>
                <a href="https://www.facebook.com/profile.php?id=100051691639299">
                  <FaFacebook className="text-3xl" />
                </a>
                <a href="https://www.linkedin.com/in/muhammad-usman-siddiqui-14475a283/">
                  <FaLinkedin className="text-3xl" />
                </a>
              </div>
              <div className="mt-6">
                <div className="flex items-center gap-3">
                  <FaLocationArrow />
                  <p>DHA, Islamabad ,Pakistan</p>
                </div>
                <div className="flex items-center gap-3 mt-3">
                  <FaMobileAlt />
                  <p>+92 336 5291751</p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Footer;
