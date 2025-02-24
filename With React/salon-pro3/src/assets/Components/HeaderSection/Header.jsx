import React from 'react';
import './Header.css';
import salonlogo from '../../homeassets/logo1.png';

function Header() {
  return (
    <header>
      <input type="checkbox" id="chk1" />
      <div className="logo">
        <img src={salonlogo} alt="Logo" width="270px" />
      </div>
      <ul>
        <li><a href="Home.html">Home</a></li>
        <li><a href="About/About.html">About</a></li>
        <li><a href="Services/Services.html">Services</a></li>
        <li><a href="Packages/Packages.html">Packages</a></li>
        <li>
          <button className="btn btn1 bookNowButton">Book Now</button>
        </li>
        <li>
          <a href="#"><i className="fab fa-facebook"></i></a>
          <a href="#"><i className="fab fa-twitter"></i></a>
          <a href="#"><i className="fab fa-instagram"></i></a>
        </li>
      </ul>
      <div className="menu">
        <label htmlFor="chk1">
          <i className="fa fa-bars"></i>
        </label>
      </div>
    </header>
  );
}

export default Header;
