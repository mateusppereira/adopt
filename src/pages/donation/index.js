import React, { Component } from 'react';
import { ScrollView, Image, TouchableOpacity, View, Text } from 'react-native';
import Header from 'components/header';
import { connect } from 'react-redux';
import { Creators as DonationActions } from 'store/ducks/donation';
import { bindActionCreators } from 'redux';
import { general, colors } from 'styles';
import styles from './styles';

class Donation extends Component {
  render() {
    return (
      <View style={general.container}>
        <Header title="Adotar" />
        <View style={styles.imagesSection}>
          <Image style={styles.photo} resizeMode="cover" source={{uri: this.props.donation.current.photos[0].photo}} />
        </View>
        <View style={styles.infoSection}>
          <Text style={styles.textHeader}>{this.props.donation.current.title}</Text>
          <ScrollView style={styles.boxDescription}>
            <Text style={styles.textDescription}>{this.props.donation.current.description}</Text>
          </ScrollView>
          <View style={general.row}>
            <Text style={styles.textKey}>Espécie: </Text>
            <Text style={styles.textValue}>{this.props.donation.current.specie}</Text>
          </View>
          <View style={general.row}>
            <Text style={styles.textKey}>Genêro: </Text>
            <Text style={styles.textValue}>{this.props.donation.current.gender}</Text>
          </View>
        </View>
        <TouchableOpacity style={styles.btnAdopt}>
          <Text style={[general.buttonText, { fontSize: 18, color: colors.dark }]}>Adotar</Text>
        </TouchableOpacity>
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

export default connect(mapStateToProps, mapDispatchToProps)(Donation)