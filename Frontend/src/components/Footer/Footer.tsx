import React from "react";
import footerLogo from "../../assets/SupportingImages/logo.png";
import FooterImg from "../../assets/SupportingImages/Footer BG.jpeg";
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
  width: "100%",
};

const FooterImpLinks: FooterLink[] = [
  { title: "Home", link: "/" },
  { title: "About", link: "/about-us" },
  { title: "Contact", link: "/contact-us" },
  { title: "Blog", link: "/#" },
];

const FooterLinks: FooterLink[] = [
  { title: "Menu", link: "/products" },
  { title: "Deal", link: "/deals" },
  { title: "Categories", link: "/categories" },
  { title: "Orders", link: "/orders" },
];

const Footer: React.FC = () => {
  return (
    <footer
      style={Img}
      className="text-white pt-5 flex flex-col justify-center min-h-[300px]"
    >
      <div data-aos="fade-in" className="container mx-auto px-6 py-10">
        <div className="grid md:grid-cols-3 gap-6">
          {/* Logo and Description */}
          <div className="text-center md:text-left">
            <h1 className="text-3xl font-bold flex items-center gap-3 mb-3">
              <img src={footerLogo} alt="Logo" className="w-12" />
              BurgerToNight
            </h1>
            <p className="text-gray-200">
              Lorem ipsum dolor sit amet consectetur adipisicing elit. Cum in
              beatae ea recusandae blanditiis veritatis.
            </p>
          </div>

          {/* Links Section */}
          <div className="grid grid-cols-2 gap-4">
            <div>
              <h2 className="text-xl font-bold mb-3">Important Links</h2>
              <ul className="space-y-2">
                {FooterImpLinks.map((item) => (
                  <li key={item.title}>
                    <Link
                      to={item.link}
                      className="hover:text-primary transition duration-300"
                    >
                      {item.title}
                    </Link>
                  </li>
                ))}
              </ul>
            </div>
            <div>
              <h2 className="text-xl font-bold mb-3">Links</h2>
              <ul className="space-y-2">
                {FooterLinks.map((item) => (
                  <li key={item.title}>
                    <Link
                      to={item.link}
                      className="hover:text-primary transition duration-300"
                    >
                      {item.title}
                    </Link>
                  </li>
                ))}
              </ul>
            </div>
          </div>

          {/* Contact and Socials */}
          <div className="text-center md:text-left">
            <div className="flex justify-center md:justify-start gap-4 mb-4">
              <a
                href="https://www.instagram.com/usman.the.coder/"
                aria-label="Instagram"
              >
                <FaInstagram className="text-3xl hover:text-primary transition" />
              </a>
              <a
                href="https://www.facebook.com/profile.php?id=100051691639299"
                aria-label="Facebook"
              >
                <FaFacebook className="text-3xl hover:text-primary transition" />
              </a>
              <a
                href="https://www.linkedin.com/in/muhammad-usman-siddiqui-14475a283/"
                aria-label="LinkedIn"
              >
                <FaLinkedin className="text-3xl hover:text-primary transition" />
              </a>
            </div>
            <div className="space-y-2">
              <p className="flex items-center gap-2">
                <FaLocationArrow />
                DHA, Islamabad, Pakistan
              </p>
              <p className="flex items-center gap-2">
                <FaMobileAlt />
                +92 336 5291751
              </p>
            </div>
          </div>
        </div>
      </div>
      {/* Footer Bottom */}
      <div className="bg-black text-gray-400 text-center py-3 mt-auto">
        &copy; {new Date().getFullYear()} BurgerToNight. All rights reserved.
      </div>
    </footer>
  );
};

export default Footer;
