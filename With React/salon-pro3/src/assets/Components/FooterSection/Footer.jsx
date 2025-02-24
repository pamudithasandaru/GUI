import React from 'react';
import './Footer.css';
import salonlogo1 from '../../homeassets/logo1.png';

function Footer() {
  return (
    <footer>
      <div className="row">
        {/* Column 1: Logo and Description */}
        <div className="col">
          <img src={salonlogo1} className="logo1" alt="Salon Lumii Logo" />
          <p>
            Welcome to Beauty lab, where you can relax and enjoy life. A little peace in a crazy world goes a long way.
          </p>
        </div>

        {/* Column 2: Office Information */}
        <div className="col">
          <h3>Office</h3>
          <p>No. 546/B</p>
          <p>Jackson Road, Moratuwa</p>
          <p>Western Province, PIN 560066, Sri Lanka</p>
          <p className="email-id">pamudithasandaru2002@gmail.com</p>
          <h4>+96 455 65 50</h4>
        </div>

        {/* Column 3: Links */}
        <div className="col">
          <h3>Links</h3>
          <ul>
            <li><a href="#home">Home</a></li>
            <li><a href="#about">About</a></li>
            <li><a href="#services">Services</a></li>
            <li><a href="#packages">Packages</a></li>
          </ul>
        </div>

        {/* Column 4: Newsletter */}
        <div className="col">
          <h3>Newsletter</h3>
          <form>
            <i className="far fa-envelope"></i>
            <input type="email" placeholder="Enter your email id" required />
            <button type="submit"><i className="fas fa-arrow-right"></i></button>
          </form>
          <div className="social-icons">
            <i className="fab fa-facebook-f"></i>
            <i className="fab fa-twitter"></i>
            <i className="fab fa-whatsapp"></i>
            <i className="fab fa-pinterest"></i>
          </div>
        </div>
      </div>
      <hr />
      <p className="copyright">
        Designed by - Pamuditha Sandaru Gunasena - EG/2022/5052
      </p>
    </footer>
  );
}

export default Footer;
