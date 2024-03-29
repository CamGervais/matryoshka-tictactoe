import React, { Component } from 'react';
import { Navbar, NavbarBrand } from 'reactstrap';
import { Link } from 'react-router-dom';
import './style/NavMenu.css';

export class NavMenu extends Component {
  render() {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
          <NavbarBrand tag={Link} to="/">Home</NavbarBrand>
        </Navbar>
      </header>
    );
  }
}
