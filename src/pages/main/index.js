import React, { Component } from 'react';
import { Text, View, TouchableOpacity, Image } from 'react-native';
import { general } from 'styles';
import styles from './styles';

const imgDog = require('../../res/dog.png');
const imgCat = require('../../res/cat.png');
const imgDogCat = require('../../res/dogcat.png');
const imgChat = require('../../res/chat.png');

class Main extends Component {
  render() {
    return (
      <View style={general.container}>
        <View style={styles.section}>
          <View style={styles.sectionAnimals}>
            <TouchableOpacity onPress={() => this.props.navigation.navigate('Search', { type: 'dogs' })} style={styles.sectionDog}>
              <Image source={imgDog} style={styles.thumbnail} />
              <Text style={styles.textDesc}>Adotar cães</Text>
            </TouchableOpacity>
            <TouchableOpacity onPress={() => this.props.navigation.navigate('Search', { type: 'cats' })} style={styles.sectionCat}>
              <Image source={imgCat} style={styles.thumbnail} />
              <Text style={styles.textDesc}>Adotar gatos</Text>
            </TouchableOpacity>
          </View>
        </View>
        <View style={styles.section}>
          <TouchableOpacity onPress={() => this.props.navigation.navigate('Add')} style={styles.sectionDogCat}>
            <Image source={imgDogCat} resizeMode="stretch" style={styles.thumbnailDogCat} />
            <Text style={styles.textDesc}>Registrar cães e gatos</Text>
          </TouchableOpacity>
        </View>
        <View style={styles.section}>
          <TouchableOpacity onPress={() => this.props.navigation.navigate('Chat')} style={styles.sectionChat}>
            <Image source={imgChat} resizeMode="stretch" style={styles.thumbnailChat} />
            <Text style={styles.textDesc}>Mensagens</Text>
          </TouchableOpacity>
        </View>
      </View>
    );
  }
}

export default Main