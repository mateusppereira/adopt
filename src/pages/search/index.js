import React, { Component } from 'react';
import { TouchableOpacity, Image, FlatList, View, Text } from 'react-native';
import Header from 'components/header';
import { connect } from 'react-redux';
import { Creators as DonationActions } from 'store/ducks/donation';
import { bindActionCreators } from 'redux';
import { general, colors } from 'styles';
import styles from './styles';

class Search extends Component {

  componentWillMount() {
    this.props.DonationActions.get();
  }

  openDonation = (item) => {
    this.props.DonationActions.setCurrent(item);
    this.props.navigation.navigate('Donation');
  }

  renderDonation = (item) => (
    <TouchableOpacity onPress={() => this.openDonation(item)} style={[general.box, general.row]}>
      <View style={styles.sectionPhoto}>
        <Image
          style={styles.thumbnail}
          source={{uri: item.photos[0].photo}}
        />
      </View>
      <View style={styles.sectionInfos}>
        <View style={general.row}>
          <Text style={general.textKey}>Nome: </Text>
          <Text style={general.textValue}>{item.title}</Text>
        </View>
        <View style={general.row}>
          <Text style={general.textKey}>Descrição: </Text>
          <Text numberOfLines={1} style={general.textValue}>{item.description}</Text>
        </View>
        <View style={general.row}>
          <Text style={general.textKey}>Genêro: </Text>
          <Text style={general.textValue}>{item.gender}</Text>
        </View>
      </View>
    </TouchableOpacity>
  )

  render() {
    return (
      <View style={general.container}>
        <Header title="Buscar" />
        <FlatList
          data={this.props.donation.list}
          keyExtractor={item => String(item.cdDonation)}
          renderItem={({ item }) => this.renderDonation(item)}
          ItemSeparatorComponent={() => <View style={general.separator} />}
        />
      </View>
    );
  }
}


const mapStateToProps = state => ({
  donation: state.donation,
});

const mapDispatchToProps = dispatch => ({
  DonationActions: bindActionCreators(DonationActions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(Search)