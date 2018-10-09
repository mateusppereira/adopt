import React, { Component } from 'react';
import { ActivityIndicator, Image, StatusBar, Text, TextInput, TouchableOpacity, View } from 'react-native';
import { colors, general } from 'styles';
import { connect } from 'react-redux';
import { Creators as LoginActions } from 'store/ducks/login';
import { bindActionCreators } from 'redux';
import styles from './styles';

const img = require('../../res/marca.png');

class Login extends Component {
  state = {
    login: null,
    password: null,
    loading: false,
  }

  doLogin = () => {
    // this.props.navigation.navigate('Signup')
    this.props.LoginActions.callLogin(this.state.login, this.state.password, this.props.navigation)
  }

  render() {
    return (
      <View style={[general.container, { backgroundColor: colors.white }]}>
        <StatusBar backgroundColor={colors.white} />        
        <View style={styles.header}>
          <Image resizeMode="contain" source={img} style={{width: '80%', height: 200}} />
        </View>
        <View style={styles.body}>
          <View style={[general.box, { flexDirection: 'column' }]}>
            <TextInput
              style={styles.input}
              placeholder="Login"
              underlineColorAndroid={colors.transparent}
              onChangeText={(text) => this.setState({ login: text })}
            />
            <TextInput
              style={styles.input}
              placeholder="password"
              underlineColorAndroid={colors.transparent}
              onChangeText={(text) => this.setState({ password: text })}
            />
            <TouchableOpacity
              style={styles.btnEntrar}
              onPress={this.doLogin}
            >
              { this.props.login.loading ? 
                <ActivityIndicator color="#000" size={18} />
                : <Text style={general.buttonText}>Entrar</Text>
              }
            </TouchableOpacity>
            <Text>{this.props.login.error}</Text>
          </View>
        </View>
      </View> 
    );
  }
}

const mapStateToProps = state => ({
  login: state.login,
});

const mapDispatchToProps = dispatch => ({
  LoginActions: bindActionCreators(LoginActions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(Login)