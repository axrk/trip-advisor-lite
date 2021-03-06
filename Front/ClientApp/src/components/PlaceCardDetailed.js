import React, { Component } from 'react';
import {
	Container,
	Row,
	Col,
	Button
} from 'reactstrap';
import { Link } from 'react-router-dom';
import './CommentCard.css';

export class PlaceCardDetailed extends Component {
	static displayName = PlaceCardDetailed.name;

	constructor(props) {
		super(props);
		this.state = {
			Comments: [],
			Tags: []
		};
	}

	componentDidMount() {
		this.populateCommentsList();
		this.populateTagsList();
	}

	async populateCommentsList() {
		if (this.props.id) {
			const res = await fetch('comments/place/' + this.props.id, {
				method: 'GET',
				headers: { 'Content-type': 'application/json' }
			});

			if (res.ok) {
				res.json().then(data => this.setState({ Comments: data }));
			} else {
				this.setState({ Comments: null });
			}
		} else {
			this.setState({ Comments: null });
		}
	}

	async populateTagsList() {
		if (this.props.id) {
			const res = await fetch('/places/' + this.props.id + '/tags', {
				method: 'GET',
				headers: { 'Content-type': 'application/json' }
			});

			if (res.ok) {
				res.json().then(data => { this.setState({ Tags: data }); console.log(data); });
			} else {
				this.setState({ Tags: null });
			}
		} else {
			this.setState({ Tags: null });
		}
	}

	AvgRank(comments) {
		let total = comments.length;
		let avg = 0;
		comments.map(comment => avg += comment.rank);
		return avg / total;
	}

	renderTagsList = () => {
		if ((this.state.Tags !== null) && (this.state.Tags.length !== 0)) {
			return (
				<Row className="pb-5">
					{ this.state.Tags.map(tag => {
						return (<Col className="m-1 bg-color rounded mb-0 text-center" style={{ backgroundColor: 'lightgrey' }}>{tag.type}</Col>);
					})
					}
				</Row>
			);
		}
		else {
			return (<Row className="pb-5">Pas de tags</Row>);
		}
	}

	render() {
		let numberComments = null;
		
		if ((this.state.Comments !== null) && (this.state.Comments.length !== 0)) {
			let avg = this.AvgRank(this.state.Comments).toFixed(1);
			numberComments =
				<div>
					Note moyenne ({this.state.Comments.length} avis)<br />
					<div className="stars-outer m-0">
						&#x02606;&#x02606;&#x02606;&#x02606;&#x02606;
						<div className="stars-inner" style={{ width: avg / 5 * 100 + '%'}}>
							&#x02605;&#x02605;&#x02605;&#x02605;&#x02605;
						</div>
					</div>
				</div>;
		}

		return (
			<Container fluid>
				<Row>
					<Col className="h3 p-0 font-weight-bold">{this.props.title}</Col>
				</Row>
				<Row>
					<Col className="h5 p-0">{this.props.street}<br/>{this.props.city + ', ' + this.props.state}</Col>
				</Row>
				<Row>
					<Col className="h5 px-0 pb-3">{numberComments}</Col>
				</Row>
				<Row className="pb-3">
					<img width="100%" src="/img_bidon.jpg" alt="A beautiful place" />
				</Row>
				{this.renderTagsList()}
				<Row>
					<Button tag={Link} to={"/place/" + this.props.id + "/addcomment"} color="success">Ajouter un avis</Button>
				</Row>
			</Container>
		);
	}
}
