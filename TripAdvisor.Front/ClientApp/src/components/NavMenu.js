import React, { Component } from 'react';
import {
	Collapse,
	Container,
	Navbar,
	NavbarBrand,
	NavbarToggler,
	NavItem,
	NavLink,
	DropdownToggle,
	DropdownMenu,
	DropdownItem,
	UncontrolledDropdown
} from 'reactstrap';
import { Link } from 'react-router-dom';
import { SearchBar } from './SearchBar';
import './NavMenu.css';

export class NavMenu extends Component {
	static displayName = NavMenu.name;

	constructor(props) {
		super(props);

		this.toggleNavbar = this.toggleNavbar.bind(this);
		this.state = {
			collapsed: true,
			appState: props.appState,
			setToken: props.setToken
		};
	}

	toggleNavbar() {
		this.setState({
			collapsed: !this.state.collapsed
		});
	}

	componentWillReceiveProps(nextProps) {
		this.setState({ appState: nextProps.appState });
	}

	render() {
		const isLoggedIn = this.state.appState.token;
		console.log(isLoggedIn);
		let button = null;

		if (isLoggedIn) {
			button = <NavItem>
				<UncontrolledDropdown nav inNavbar>
					<DropdownToggle nav caret>
						Mon compte
					</DropdownToggle>
					<DropdownMenu right>
						<DropdownItem>
							Profil
                        </DropdownItem>
						<DropdownItem onClick={() => {
							localStorage.clear();
							this.state.setToken(null);
						}}>
							Deconnexion
                        </DropdownItem>
					</DropdownMenu>
				</UncontrolledDropdown>
			</NavItem >;
		} else {
			button = <NavItem>
				<NavLink tag={Link} className="text-dark" to="/login">Connexion</NavLink>
			</NavItem>;
		}

		return (
			<header>
				<Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
					<Container>
						<NavbarBrand tag={Link} to="/" className="font-weight-bold">
							<img
								src="/logo.png"
								width="35"
								height="35"
								className="d-inline-block align-middle mr-2"
								alt="TripAdvisor logo"
							/>
							Trip Advisor Lite
						</NavbarBrand>

						<NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
						<Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
							<SearchBar />
							<div className="navbar-nav flex-grow">
								{button}
								<NavItem>
									<NavLink tag={Link} className="text-dark pl-5" to="/counter">Ecrire un avis</NavLink>
								</NavItem>
							</div>
						</Collapse>
					</Container>
				</Navbar>
			</header>
		);
	}
}
