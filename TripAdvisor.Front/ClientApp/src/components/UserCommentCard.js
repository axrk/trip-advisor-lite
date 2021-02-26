﻿import React, { Component } from 'react';
import {
	Container,
	Row,
	Col
} from 'reactstrap';

export class UserCommentCard extends Component {
	static displayName = UserCommentCard.name;

	constructor(props) {
		super(props);
		this.state = {
			Place: [],
		};
	}

	componentDidMount() {
		this.findPlace();
	}

	async findPlace() {
		const res = await fetch('places/' + this.props.place, {
			method: 'GET',
			headers: { 'Content-type': 'application/json' }
		});
		console.log(res);

		if (res.ok) {
			res.json().then(data => this.setState({ Place: data }));
		} else {
			this.setState({ Place: null });
		}
	}

	render() {
		return (
			<Container fluid className="border mb-2">
				<Row className="pt-2">
					<Col className="h4 font-weight-bold">{ this.state.Place.title }, { this.state.Place.city }</Col>
				</Row>
				<Row className="pb-1">
					<Col className="h5 font-weight-bold">{this.props.title}</Col>
					<Col className="h5 text-right">{this.props.rank}/5</Col>
				</Row>
				<Row className="pb-2">
					<Col>{this.props.content}</Col>
				</Row>
				<Row className="pb-2">
					<Col>Date de visite : {this.props.date}</Col>
				</Row>
			</Container>
		);
	}
}